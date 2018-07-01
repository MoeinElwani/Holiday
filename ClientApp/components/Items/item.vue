<template>
  
  <div>
    <br></br>
    <BlockUI v-if="showblock" :message="message"  >
      <h1>
        <icon icon="spinner" pulse=""/>
      </h1>
    </BlockUI>
   <!--<qrcode value="Hello, World!" :options="{ size: 20 }"></qrcode>--> 
    
    <b-modal ref="myModalRef" hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>
  
    </br>
    <b-card bg-variant="light">
    <div class="row">
      <div align="center" class="col-sm-2" >
        <b-form-group  size="lg"  id="exampleInputGroup1"
                        label="المجموعة:"
                        label-for="exampleInput1"
                        align="right"
                        label-size="lg"
                      >

          <b-form-select size="lg" text-field="groupDes"  value-field="groupId" v-model="selected" :options="groups" class="mb-3" />
        </b-form-group>
      </div>
      <div align="center" class="col-sm-3" >
        <b-form-group  size="lg"  id="exampleInputGroup1"
                        label="الأقسام:"
                        label-for="exampleInput1"
                        align="right"
                        label-size="lg"
                      >
          <b-form-select size="lg" text-field="depDesc" change="GetTypebyDepartments(99)" value-field="depId" v-model="selecteddepartment" :options="departments" class="mb-3" />
        </b-form-group>
      </div>
      <div align="center" class="col-sm-3" >
        <b-form-group  size="lg"  id="exampleInputGroup1"
                        label="الأنواع:"
                        label-for="exampleInput1"
                        align="right"
                        label-size="lg"
                      >

          <b-form-select size="lg" text-field="typeDesc"  value-field="typeId" v-model="selectedtypes" :options="types" class="mb-3" />
        </b-form-group>
      </div>
      <div class="col-sm-2"  align="center">
        <b-form-group id="exampleInputGroup2"
                         label-size="lg"
                        label="أسم الصنف:"
                        label-for="exampleInput2"
                        align="right"
                      >
          <b-form-input size="lg"   align="center" v-model="searshname"
                  type="text"
                  placeholder="أدخل أسم الصنف"></b-form-input>
        </b-form-group>
      </div>
      <div class="col-sm-2"  align="center">
        <b-form-group  size="lg"  id="exampleInputGroup1"
                      label="الشركة:"
                      label-for="exampleInput1"
                      align="right"
                      label-size="lg"
                      >

          <b-form-select size="lg" text-field="compDes"  value-field="compId" v-model="selectedcompaies" :options="compaies" class="mb-3" />
        </b-form-group>
      </div>
    </div>

    <b-card bg-variant="light" header="header"
             align="right"  header-tag="header">
     
        <b-badge   slot="header" variant="light">
          <b-button @click.prevent="visibility='all' "           variant="primary">الكل</b-button>
          <b-button @click.prevent="visibility='discounted' "    variant="success"   >المخفظة</b-button>
          <b-button @click.prevent="visibility='undiscounted' "    variant="warning"   >غير مخفضة</b-button>
          <b-button @click.prevent="visibility='cannotdiscount' "    variant="warning"   >غير قابلة للتخفيض</b-button>
          <b-btn v-if="itemstoedit.length>0"  v-b-modal.modalPrevent=""> معالجة</b-btn>
        
        </b-badge>
          <b-modal size="lg" id="modalPrevent"
          ref="modal"
          title="معالجة"
          @ok="handleOk"
          align="right"
          @shown="clearName">
                       
            <b-form-group dir="rtl"
                breakpoint="lg"
              align="right"
                label-size="lg"
                label-class="font-weight-bold pt-0"
                class="mb-0">
              <form @submit.stop.prevent="handleSubmit">
                <b-container fluid="">
                <b-row >
                  <b-col sm="6">
                <b-form-radio-group  v-model="selectedprocess"
                                    :options="options"
                                    stacked=""
                                    align="right"
                                    >
                </b-form-radio-group>
                  </b-col>
                </b-row>
                 </br>
                  <b-row >
                    <b-col sm="2">
                      <p v-if="selectedprocess==1">نسبة التخفيض</p>
                      <p v-if="selectedprocess==2">عدد الأيام</p>
                    </b-col>
                  <b-col sm="2">
                      <b-form-input size="Sm"  v-if="selectedprocess==1 || selectedprocess==2  "  type="number"
                       placeholder="Enter item code "
                       v-model="number"></b-form-input>
                  </b-col>
                  </b-row>
                

                 
                </b-container>
               </form>
            </b-form-group>
            <div class="mt-3 mb-3">
              <b-form-checkbox id="checkbox1"
                    v-model="selectalltype"
                    @change="checkboxToggle()"
                    value="معالجة الأصناف المحددة"
                    unchecked-value="عدم معالجة الأصناف المحددة">

              </b-form-checkbox>
                <strong>{{selectalltype}}</strong>
              
            </div>
            <div class="mt-3 mb-3">
              <strong>عدد الأصناف المحددة {{itemstoedit.length}}</strong>
            </div>

            
          </b-modal>
          

      <div class="row" v-if="items" >
        <div class="col-sm-3">
          الأجمالي : {{ total}}<input size="1" type="number" v-model="pageSize"></input>

        </div>
        <div class="col-sm-6">
          <b-pagination align="center" size="md" :total-rows="total" v-model="currentPage" :per-page="pageSize">
          </b-pagination>
        </div>
        <div class="col-sm-3">

        </div>
    

      </div>
   
     
      <template v-if="items">
        <table class="table table-sm table-striped">

          <thead  class="bg-primary text-white">
            <tr align="center">
              <th>الرقم</th>
              <th>الاسم</th>
              <th>التكلفة</th>
              <th>السعر</th>
              <th>هامش</th>
              <th>الكمية</th>
              <th>المباع</th>
              <th>أخر بيع</th>
              <th>بعد التخفيض</th>
              <th>التخفيض</th>
              <th>الترجيع</th>
              <th>المجموعة</th>
              <th>الحالة</th>
              <th>الشركة</th>
              <th>تحديد</th>
             
            </tr>
          </thead>
          <tbody >
            <tr align="center" v-for="(item,index) in filterditems"   :key="index" >
      
              <td>{{ item.codebar }} </td>
              <td>{{ item.itemName }}  </td>
              <td>{{ item.cost }}  </td>
              <td>{{item.price2}}</td>
              <td>{{ formatPrice((item.price2/item.cost) -1) }}</td>

              <td>{{item.inStock}}</td>
              <td>{{item.soldqyt}}</td>
              <td v-if="item.lastSoldDate">
                <vueDateFormat :format="format" :time="item.lastSoldDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
              </td>
              <td v-if="!item.lastSoldDate">{{ item.lastSoldDate  }}</td>
              <td>{{item.packagePrice}}</td>
             
              <td> {{item.discount}} </td>
              <td>{{item.daysReverse}}</td>
              <td>{{item.enNum}}</td>
              <td>{{item.stopSaleF}}</td>
              <td>{{item.compId}}</td>
              <td>
                <input @click="SlectItem(item)" type="checkbox" id="checkbox" v-model="item.snF"/>
               
              </td>

            </tr>
          </tbody>
        </table>
     
     
    </template>
      
    </b-card>
    </b-card>
  </div>
</template>

<script src="./itemCom.js"> </script>

<style>
  .checkmark {
  position: absolute;
  top: 0;
  left: 0;
  height: 25px;
  width: 25px;
  background-color: #eee;
  }
</style>
