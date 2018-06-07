<template>
  
  <div>


    <b-modal ref="myModalRef" hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>
    <div class="row">
      <div class="col-sm-9"></div>
      <div class="col-sm-3">
        <b-button @click.prevent="CreateNewticket"  size="lg" variant="primary">جديد</b-button>

      </div>
    </div>
    
    <b-modal bodyBgVariant="danger"  size="lg" id="modalPrevent"
         ref="modal"
         title="أضف عنصر"
         @ok="handleOk"
         @shown="clearName">
      <form @submit.stop.prevent="handleSubmit">
        <b-form-input type="number"
                      placeholder="Enter item code "
                      v-model="id"></b-form-input>
      </form>
    </b-modal>
    <b-modal dir="rtl"  size="lg" id="modalPAyp"
         ref="modalPAy"
         title="أتمام الفاتورة"
         @ok="SubmitTicket"
         @shown="clearName">
      <b-form-group dir="rtl"
                     breakpoint="lg"
                   align="right"
                     label-size="lg"
                     label-class="font-weight-bold pt-0"
                     class="mb-0">
      <div class="mt-3 mb-3">
        <strong>الأجمالي :{{total + totaldiscount}}</strong>
      </div>
      <div class="mt-3 mb-3">
        <strong>التخفيض :{{totaldiscount}}</strong>
      </div>
      <div class="mt-3 mb-3">
        <strong>بعد التخفيض :{{total}}</strong>
      </div>
      </b-form-group>
    </b-modal>
    
    <template v-if="newticket" >
    <br></br>
    <b-card bg-variant="light" >
   
      <div class="row">
        <div align="right" class="col-sm-3" >
          <b-btn  size="lg" v-b-modal.modalPrevent=""> الأصناف</b-btn>
          <b-btn  size="lg" v-b-modal.modalPAyp=""> دفع</b-btn>
          <b-button @click.prevent="SuspendTicket"  variant="primary">تعليق</b-button>
        </div>
        <div align="center" class="col-sm-3" >
            <b-form-group  size="sm"  id="exampleInputGroup1"
                               label="طريقة الدفع:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="sm"
                      >

        <b-form-select size="sm" text-field="paymentDes" value-field="paymentId" v-model="payment" :options="payments" class="mb-3" />
      </b-form-group>
        </div>
        <div align="center" class="col-sm-3" >
          <b-form-group  size="sm"  id="exampleInputGroup1"
                               label="التاريخ:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="sm"
                      >{{date | moment("DD-MM-YYYY, h:mm")}}</b-form-group>
          
        </div>
   
        <div class="col-sm-3"  align="center">

        </div>
      </div>
     
    </b-card>
    </br>
   
   
      <b-card  align="right" bg-variant="light" header="featured" footer="featured" footer-tag="footer"
                header-tag="header">
        <b-badge   slot="header"  variant="light">
          {{ticket.invoiceId}}
        </b-badge>
        <b-badge   slot="footer"  variant="light">
          {{total}}  {{totaldiscount}}
        </b-badge>
        <template v-if="payments.length!=0" >
          <table class="table borderd">
            <thead  class="bg-primary text-white">
              <tr>
                <th>رقم</th>
                <th>الاسم</th>
                <th  width="3">الكمية</th>
                <th>السعر</th>
                <th>التخفيض</th>
                <th>المجموع</th>
                <th>حدف</th>
              </tr>
            </thead>
            <tbody >
              <tr  v-for="(sale,index)  in sales" :key="index" >
                <td>{{index+1}}</td>
                <td>{{ sale.itemname }}</td>
                <td width="3">
                  <input @change="EditSaleQuantity(sale)" size="1" type="number" v-model="sale.qyt" ></input> </td>
                <td>{{sale.price}}</td>
                <td>{{sale.price-sale.disAmount }}</td>
                <td>{{sale.total}}</td>
                <td>
                  <b-button  @click="RemoveSaleFromTicket(sale)" size="sm" variant="success">
                    <icon icon="list" class="mr-2" />
                  </b-button>
                </td>
              </tr>
            </tbody>
          </table>
        </template>

      </b-card>
  </template>

    <template v-if="!newticket">
      <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
          <b-card  align="right" bg-variant="light" header="featured" footer="featured" footer-tag="footer"
 header-tag="header">
            <b-badge   slot="header"  variant="light">
              <strong>الفواتير المعلقة</strong>
            </b-badge>
            <b-badge   slot="footer"  variant="light">

            </b-badge>
            <template  >
              <table class="table borderd">
                <thead  class="bg-primary text-white">
                  <tr>
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                    <th>التخفيض</th>
                    <th>الوقت</th>
                    <th>فتح</th>
                    <th>'</th>
                  </tr>
                </thead>
                <tbody >
                  <tr  v-for="(ticket,index)  in tickets" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{ticket.total}}</td>
                    <td>{{ticket.dis}}</td>
                    <td> {{ticket.createdDate | moment("DD-MM-YYYY, h:mm")}}</td>
                    <td>
                    <b-button  @click="OpenExistTicket(ticket)" size="sm" variant="success">
                      فتح
                    </b-button>
                    </td>
                    <th>{{ticket.paymentId}}</th>
                  </tr>
                </tbody>
              </table>
            </template>

          </b-card>
        </div>
        <div class="col-sm-2"></div>
      </div>
     
      
    </template>
    
  </div>
  
</template>

<script src="./PosCom.js"> </script>

<style>
</style>
