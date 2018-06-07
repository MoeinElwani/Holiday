<template>
  
  <div>
    <b-modal ref="myModalRef" hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>
    <br></br>
    <div v-if="!payments" class="text-center">
      <p>
        <em>Loading...</em>
      </p>
      <h1>
        <icon icon="spinner" pulse=""/>
      </h1>
    </div>
    <template v-if="!show" >
      <b-card bg-variant="light" 
                >
       
      
    <table class="table borderd">
      <thead  class="bg-primary text-white">
        <tr>
          <th>الرقم</th>
          <th>الاسم</th>
          <th>الحالة</th>
          <th>التخفيض</th>
          <th>تعديل</th>
        </tr>
      </thead>
      <tbody >
        <tr  v-for="(payment,index)  in payments" :key="index" >
          <td>{{ payment.paymentId }}</td>
          <td>{{ payment.paymentDes}}  </td>
          <td>
           
            <b-form-checkbox id="checkbox1"
                disabled=""  v-model="payment.status"
               >
            
            </b-form-checkbox>

          </td>
          <td>{{ payment.discount}}  </td>
          <td>
            <b-button  @click="edit(payment)"  variant="success">
              <icon icon="list" class="mr-2" />
            </b-button>
          </td>
           
        </tr>
      </tbody>
    </table>

      </b-card>
  </template>
    <template  v-if="show">
      <BlockUI v-if="showblock" :message="message"  >
        <h1>
          <icon icon="spinner" pulse=""/>
        </h1>
      </BlockUI>
     
      <b-card align="right"  bg-variant="light">   
        <div dir="rtl" >
          <b-form @submit="onSubmit" @reset="onReset" >
            <b-form-group id="exampleInputGroup1"
                          label="أسم الطريقة:"
                          label-for="exampleInput1"
                         >
              <b-form-input id="exampleInput1"
                            type="text"
                            v-model="payment.PaymentDes"
                            required=""
                            placeholder="أسم الطريقة">
                
              </b-form-input>
            </b-form-group>

           

            <b-form-group id="exampleInputGroup2"
                        label="نسبة التخفيظ"
                        label-for="exampleInput2">
              <b-form-input id="exampleInput2"
                            type="number"
                            v-model="payment.discount"
                            required=""
                            placeholder="نسبة التخفيض">
              </b-form-input>
            </b-form-group>

            <b-form-group id="exampleGroup4">


              <label class="container">
                الحالة&nbsp
                <input v-model="payment.Status" type="checkbox" checked="checked"/>
                <span class="checkmark"></span>
              </label>

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

<script src="./PaymentCom.js"> </script>

<style>
  .container {
  display: block;
  position: relative;
  padding-left: 12px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 18px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  }

  /* Hide the browser's default checkbox */
  .container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
  }

  /* Create a custom checkbox */
  .checkmark {
  position: absolute;
  top: 0;
  left: 44;
  height: 25px;
  width: 25px;
  background-color: #fff;
  }

  /* On mouse-over, add a grey background color */
  .container:hover input ~ .checkmark {
  background-color: #ccc;
  }

  /* When the checkbox is checked, add a blue background */
  .container input:checked ~ .checkmark {
  background-color: #2196F3;
  }

  /* Create the checkmark/indicator (hidden when not checked) */
  .checkmark:after {
  content: "";
  position: absolute;
  display: none;
  }

  /* Show the checkmark when checked */
  .container input:checked ~ .checkmark:after {
  display: block;
  }

  /* Style the checkmark/indicator */
  .container .checkmark:after {
  left: 9px;
  top: 5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
  }
</style>
