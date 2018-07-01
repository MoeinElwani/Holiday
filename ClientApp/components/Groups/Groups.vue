<template>
  
  <div>
    <b-modal ref="myModalRef" hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>
    <br></br>
    <div v-if="!groups" class="text-center">
      <p>
        <em>Loading...</em>
      </p>
      <h1>
        <icon icon="spinner" pulse=""/>
      </h1>
    </div>
    <template v-if="!show" >
      <b-card bg-variant="light" header="header"
                header-tag="header" align="right">
    <b-badge slot="header" variant="light">
          <b-button @click.prevent="visibility='all' "           variant="primary">كل المجموعات</b-button>
          <b-button @click.prevent="visibility='discounted' "    variant="success"   >المخفظة</b-button>
          <b-button @click.prevent="visibility='revesabel' "     variant="warning">القابلة للترجيع</b-button>
        </b-badge>

    
        
    <table class="table borderd  table-striped">
      <thead  class="bg-primary text-white">
        <tr>
          <th>الاسم</th>
          <th>أيام الأسترجاع</th>
          <th>التخفيض</th>
          <th>تعديل</th>
        </tr>
      </thead>
      <tbody >
        <tr  v-for="(group,index)  in filterdGroups" :key="index" >
          <td>{{ group.groupDes}}  </td>
          <td>{{ group.daysReverse}} </td>
          <td>{{ group.discount}} % </td>
          <td>
            <b-button  @click="edit(group)" size="sm" variant="success">
              <icon icon="edit" class="mr-2" />
         
            </b-button>
          </td>
     
        </tr>
      </tbody>
    </table>

      </b-card>
  </template>
  <template  v-if="show">
        <BlockUI v-if="showblock" :message="message" :url="url" ></BlockUI>
     
      <b-card align="right" bg-variant="light">   
        <div>
          <b-form @submit="onSubmit" @reset="onReset" >
            <b-form-group id="exampleInputGroup1"
                          label="أسم المجموعة:"
                          label-for="exampleInput1"
                         >
              <b-form-input id="exampleInput1"
                            type="text"
                            v-model="group.GroupDes"
                            required=""
                            placeholder="أسم المجموعة">
                
              </b-form-input>
            </b-form-group>
            <b-form-group id="exampleInputGroup2"
                       label="أيام الترجيع"
                       label-for="exampleInput2">
              <b-form-input id="exampleInput2"
                            type="number"
                            v-model="group.DaysReverse"
                            required=""
                            placeholder="أيام الترجيع">
              </b-form-input>
            </b-form-group>
            <b-form-group id="exampleInputGroup2"
                        label="نسبة التخفيظ"
                        label-for="exampleInput2">
              <b-form-input id="exampleInput2"
                            type="number"
                            v-model="group.Discount"
                            required=""
                            placeholder="نسبة التخفيض">
              </b-form-input>
            </b-form-group>
            <br></br>
            <b-button type="submit" variant="primary">حفظ</b-button>
            <b-button type="reset" variant="danger">مسح</b-button>
           
          </b-form>
        </div>
      </b-card>
      <br></br>
    </template>
  </div>
  
</template>

<script src="./GroupsCom.js"> </script>

<style>
</style>
