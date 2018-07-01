<template>
  
  <div>
    <BlockUI v-if="showblock" :message="message"  >
      <h1>
        <icon icon="spinner" pulse=""/>
      </h1>
    </BlockUI>
    <div class="row">
      <br></br>
      <div v-if="!newticket" class="col-sm-3" align="right">
        <br></br>
        <b-button @click.prevent="CreateNewticket"  size="lg" variant="primary">جديد</b-button>
      </div>
    </div>
    <b-modal ref="myModalRef"  @hidden="cnsl" hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>  
    <b-modal id="modalPrevent" bodyBgVariant="light" hide-header="" size="lg" 
         ref="modal"
         title="أضف عنصر"
         @hidden="cnsl"
         @ok="handleOk"
         @shown="clearName">
      <b-container fluid="">
        
      <b-card bg-variant="light" align="right"  >
        <b-row>
          <b-col cols="3">
            <b-form-checkbox id="checkbox1"
              v-model="quantype"
              @change="checkboxToggle()"
              value="يوجد مخزون"
              unchecked-value="كل الأصناف">
            </b-form-checkbox>
            <strong>{{quantype}}</strong>
          </b-col>
          <b-col cols="9">
            <b-form-input type="text"
              placeholder="أدخل اسم الصنف"
              v-model="itemname">
            </b-form-input>
          </b-col>
        </b-row>
        </br>
     
        <Key-board   type="1" v-model="itemname"   v-on:dojob="SetKeyboard($event)"></Key-board>


        <div v-if="items.length  > 0" bg-variant="light" align="right" >
          <table  class="table table-striped table-sm">
            <thead  class="bg-primary text-white">
              <tr>
                <th>الاسم</th>
                <th>السعر</th>
                <th>الكمية</th>
                <th>أختيار</th>
              </tr>
            </thead>
            <tbody >
              <tr  v-for="(item,index) in items"   :key="index" >
                <td>{{ item.itemName }}  </td>
                <td>{{item.itemPrice}}</td>
                <td>{{item.inStock}}</td>
                <td>
                  <b-button  @click="additem(item)" size="sm" variant="success">
                    /\
                  </b-button>
                </td>
              </tr>
            </tbody>
          </table>
          <b-pagination align="center" size="md" :total-rows="totals" v-model="currentPage" :per-page="10">
          </b-pagination> الأجمالي : {{ totals}}
          </div>
      </b-card>

   
      </b-container>
    </b-modal>
    <b-modal id="modalPAyp"      dir="rtl"  size="lg" 
         ref="modalPAy"
         title=" أتمام فاتورة "
             @hidden="cnsl"
         @ok="SubmitTicket"
         @shown="clearName">
      <b-container fluid="">

        <b-card bg-variant="light" align="right">


        <b-row>

          <b-col cols="4">
            <h3>
              <p class="text-primary">الأجمالي :{{formatPrice(total + totaldiscount)}}</p>
            </h3>
          </b-col>
          <b-col cols="4">
            <h3>
              <p class="text-success">التخفيض :{{formatPrice(totaldiscount)}}</p>
            </h3>
          </b-col>
          <b-col cols="4">
            <h3>
              <p class="text-danger">بعد التخفيض :{{formatPrice(total)}}</p>
            </h3>
          </b-col>


        </b-row>
          <b-row>
            <b-col  cols="4">
              <b-form-group  size="lg"  id="exampleInputGroup1"
               
                align="right"
                label-size="lg"
                      >

                <b-form-select size="lg" text-field="cusName"  value-field="cusId" v-model="cusId" :options="customers" class="mb-3" />
              </b-form-group>

            </b-col>
          <b-col  cols="8">
            <div class="input-group">
       
            </div>
            <div  class="input-group input-group-lg">
            
              <input v-focus="focused" @focus="focused = 'note';showkeyboard=true" placeholder="ملاحظة"  type="text" class="form-control" v-model="ticket.note" ></input>
            </div>
          </b-col>
       
          </b-row>

          <b-row>
            <b-col cols="12" >
    
              <Key-board v-if="showkeyboard"  type="1" v-model="cusName"    v-on:dojob="SetKeyboard($event)"></Key-board>

            </b-col>

          </b-row>
        </b-card>
        </b-container>
    </b-modal>
    
    <template v-if="newticket" >
     
    <b-card bg-variant="light" >
   
      <div class="row">
        <div align="right" class="col-sm-3" >
          </br>
          <b-btn  size="lg" v-b-modal.modalPrevent="" variant="primary">
            <icon icon="search"  /> </b-btn>
          <b-btn :disabled="total > 0? false :true " size="lg" v-b-modal.modalPAyp="" variant="danger">
            <icon icon="money-bill" /></b-btn>
          <b-btn :disabled="total > 0? false :true " size="lg" @click.prevent="SuspendTicket"  variant="warning">
            <icon icon="stop-circle"  /></b-btn>
        </div>
        <div class="col-sm-2"  align="right">
          <b-form-group  size="lg"  id="exampleInputGroup1"
                                     label="باركود:"
                                     label-for="exampleInput1"
                                     align="right"
                                     label-size="lg"
                      >
            <b-form-input id="email" size="lg"   ref="email" v-model="barcode" autofocus="" >
            </b-form-input>
          
         </b-form-group>
         
        </div>
        <div class="col-sm-1"  align="right">
          <br></br>
          <b-button @click.prevent="addbybarcode"  variant="primary">
            <icon icon="cart-plus"  /> 
          </b-button>
        </div>
        <div align="center" class="col-sm-3" >
            <b-form-group  size="lg"  id="exampleInputGroup1"
                               label="طريقة الدفع:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="lg"
                      >

        <b-form-select size="lg" text-field="paymentDes" value-field="paymentId" v-model="payment" :options="payments" class="mb-3" />
      </b-form-group>
        </div>
        <div align="center" class="col-sm-3" >
          <b-form-group  size="lg"  id="exampleInputGroup1"
                               label="التاريخ:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="lg"
                      >
            <h4> <vueDateFormat :format="format" size="lg" :time="date" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
            </h4>
          </b-form-group>
          
        </div>
      
      </div>

    </b-card>
    </br>
    <b-card  align="right" bg-variant="light" header="featured"  footer-tag="footer"
                header-tag="header">
      <div slot="header" >
        <div class="row">
          <div class="col-sm-3">
            <h3>
              <h3> فاتورة مبيعات   {{ticket.invoiceId}}</h3>
            </h3>
          </div>
          
          <div class="col-sm-3">
            <h3>
              <p class="text-primary">الأجمالي :{{formatPrice(total + totaldiscount)}}</p>
            </h3>
          </div>
          <div class="col-sm-3">
            <h3>
              <p class="text-success">التخفيض :{{formatPrice(totaldiscount)}}</p>
            </h3>
          </div>
          <div class="col-sm-3">
            <h3>
              <p class="text-danger">بعد التخفيض :{{formatPrice(total)}}</p>
            </h3>
          </div>
    


        </div>

      </div>
      
     
      
        <template v-if="payments.length!=0" >
          <table class="table table-striped ">
            <thead  class="bg-primary text-white">
              <tr align="center">
                <th>باركود</th>
                <th>الاسم</th>
             
                <th >الكمية</th>
                <th  >
                </th>
                <th>السعر</th>
                <th>التخفيض</th>
                <th>المجموع</th>
                <th>حدف</th>
              </tr>
            </thead>
            <tbody >
              <tr align="center" v-for="(sale,index)  in sales" :key="index" >
                <td>{{sale.codebar}}</td>
                <td>{{ sale.itemname }}</td>
                <td>
                  {{sale.qyt}}
                </td>
                <td >
                  <b-button  @click="EditSaleQuantity(sale,'+')" size="sm" variant="success">+</b-button>
                  <b-button  @click="EditSaleQuantity(sale,'-')" size="sm" variant="success"> - </b-button>
                </td>
               
                <td>{{formatPrice(sale.price)}}</td>
                <td>{{formatPrice(sale.price-sale.disAmount )}}</td>
                <td>{{formatPrice(sale.total)}}</td>
                <td>
                  <b-button  @click="RemoveSaleFromTicket(sale,'')" size="sm" variant="success">
                    X
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
          <b-card  align="right" bg-variant="light" header="featured"  footer-tag="footer"
                  header-tag="header">
            <div slot="header" >
              <h4>الفواتير المعلقة</h4>

            </div>
            
            <template  >
              <table class="table table-striped table-borderd">
                <thead  class="bg-primary text-white">
                  <tr align="center">
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                    <th>التخفيض</th>
                    <th>الوقت</th>
                    <th>فتح</th>
                    <th>طريقة الدفع</th>
                  </tr>
                </thead>
                <tbody >
                  <tr align="center"  v-for="(ticket,index)  in tickets" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{formatPrice(ticket.total)}}</td>
                    <td>{{formatPrice(ticket.dis)}}</td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.createdDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td>
                    <b-button  @click="OpenExistTicket(ticket)" size="sm" variant="success">
                       <icon icon="box-open"  />
                    </b-button>
                    </td>
                    <th>{{GetPaymentName(ticket.paymentId)}}</th>
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

<script src="./PosCom.js">
</script>

<style>
  .myButton {
  width: 100px;height: 100px;
  }
</style>
