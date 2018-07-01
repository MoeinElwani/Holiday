<template>
 
  <div>
    <BlockUI v-if="showblock" :message="message"  >
      <h1>
        <icon icon="spinner" pulse=""/>
      </h1>
    </BlockUI>
    </br>
    <b-modal ref="myModalRef"   hide-footer="" hide-header="" title="خطأ">
      <div class="d-block text-center">
        <h3>{{error}}</h3>
      </div>
      <b-btn class="mt-3" variant="outline-danger" block="" @click="hideModal">أغلاق</b-btn>
    </b-modal>

    
    <b-modal id="modalPAyp"  centered=""   ok-only=""  dir="rtl"  size="lg"
         ref="modalPAy"
         title="أتمام الفاتورة"        
         @ok="handleOk"
         @shown="GetCustomers">
      <b-container fluid="">
        <b-card bg-variant="light" align="right"  >
          <b-card bg-variant="light" align="right">
          <b-row>
           
          <b-col cols="3">
            <h4> <p class="text-primary">الأجمالي : {{formatPrice(total)}} </p>
            </h4>
          </b-col>
          <b-col cols="3">
            <h4><p class="text-success"> الترجيع : {{formatPrice(totalreturn)}}</p>
            </h4>
          </b-col>
          <b-col cols="6">
              <h3>
                <p class="">الزبون: {{cusName}}</p>
              </h3>
            </b-col>

        
        </b-row>
          <b-row>
              <b-col v-if="cusId==0" cols="5">

                <div class="input-group">
                  <input type="text" class="form-control" v-model="cusName" v-focus="focused" @focus="focused = 'name'"  placeholder="الأسم "  ></input>
                </div>
              </b-col>
              <b-col v-if="cusId==0" cols="5">

                <div class="input-group">
                  <input type="text" class="form-control" v-model="phone" v-focus="focused" @focus="focused = 'phone'"  placeholder=" الهاتف"  ></input>
                </div>
              </b-col>
              <b-col v-if="cusId!=0" cols="10">
                <div class="input-group">
                  <input type="text" class="form-control" v-model="ticket.note" v-focus="focused" @focus="focused = 'company';showkeyboard=true" ></input>
                </div>
              </b-col>
              <b-col cols="2">
                <b-button v-if="!showkeyboard"  @click="showkeyboard=!showkeyboard;cusId=0" size="sm" variant="success">
                  تغيير
                </b-button>
                <b-button  v-if="showkeyboard && cusId==0"  @click="AddCustomer()" size="sm" variant="success">
                  أضافة
                </b-button>
              </b-col>
            </b-row>
          </b-card>
          <b-row>
            <b-col cols="12" >
              </br>
              <Key-board v-if="showkeyboard"  type="1" v-model="cusName"    v-on:dojob="SetKeyboard($event)"></Key-board>
              
            </b-col>
      
          </b-row>              
          <b-row>
            <b-col cols="1">
              
            </b-col>
            <b-col cols="10">
              <table v-if="showkeyboard && cusId==0" size="sm" class="table table-striped table-sm">
                <thead  class="bg-primary text-white">
                  <tr>
                    <th> الأسم</th>
                    <th>الرقم</th>
                    <th>أختيار</th>
                  </tr>
                </thead>
                <tbody >
                  <tr  v-for="(customer,index)  in customers" :key="index" >
                    <td>{{customer.cusName}}</td>
                    <td>{{customer.phone}}</td>
                    <td>
                      <b-button  @click="SelectCustomer(customer)" size="sm" variant="success">
                        *
                      </b-button>
                    </td>
                  </tr>
                </tbody>
              </table>

            </b-col>
            <b-col cols="1">

            </b-col>
          </b-row>
        </b-card>
    
      </b-container>
    </b-modal>
    <template v-if="!newticket" >
   
      <b-card  bg-variant="light" >
        <div class="row">
         
          <div align="right" class="col-sm-2" >
            <b-form-group  size="lg"  id="exampleInputGroup1"
                               label="رقم الفاتورة:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="lg"
                      >
              <b-form-input      size="lg"  type="number"  v-model="invoiceId"  />
            </b-form-group>
          </div>
          <div align="center" class="col-sm-2" >
            <b-form-group  size="lg"  id="exampleInputGroup1"
                               label="طريقة الدفع:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="lg"
                      >
              <b-form-select disabled=""  size="lg" text-field="paymentDes" value-field="paymentId" v-model="payment" :options="payments" class="mb-3" />
            </b-form-group>
          </div>
          <div align="right"  class="col-sm-5" >
            <b-form-group  size="lg"  id="exampleInputGroup1"
                               label="ملاحظة:"
                               label-for="exampleInput1"
                               align="right"
                               label-size="lg"
                      >

              <b-form-input  disabled=""    size="lg"  type="text"  v-model="ticket.note"  />
            </b-form-group>

          </div>
          <div v-if="date" align="center" class="col-sm-3" >
            <b-form-group  size="lg"  id="exampleInputGroup1"
                                 label="التاريخ:"
                                 label-for="exampleInput1"
                                 align="right"
                                 label-size="lg"
                      >
              <h4>
                <vueDateFormat :format="format" size="lg" :time="date" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
              </h4>
            </b-form-group>
          </div>
         
        </div>
        <div class="row" align="right">
          <div align="right" class="col-sm-2">
           
              <b-btn   size="lg" @click="OpenExistTicket" variant="primary">
                <icon icon="search"  />
              </b-btn>
              <b-btn :disabled="(ticket.invoiceTypeId==1 && totalreturn>0)? false :true "  size="lg" v-b-modal.modalPAyp="" variant="danger">
                <icon icon="money-bill-wave"  />
              </b-btn>

          </div>

          <div align="right" class="col-sm-5">
            <Key-board type="0" v-model="invoiceId"    v-on:dojob="SetNumbers($event)"></Key-board>
          </div>
        </div>
      </b-card>
      </br>
      <template v-if="sales.length!=0">
      <b-card  align="right" bg-variant="light" header="featured" footer-tag="footer"
                  header-tag="header">
        <div  slot="header">
          <b-row>
          
            <b-col cols="3">
              <h3>
                <p class="text-primary">الأجمالي:{{formatPrice(ticket.dis + ticket.total)}} </p>
              </h3>
            </b-col>
            <b-col cols="3">
              <h3>
                <p class="text-success"> التخفيض{{formatPrice(ticket.dis)}}</p>
              </h3>
            </b-col>
            <b-col cols="3">
              <h3>
                <p class="text-danger">بعد التخفيض :{{formatPrice(ticket.total)}}</p>
              </h3>
            </b-col>
            <b-col cols="3">
              <h3>
                <p class="text-danger"> الترجيع :{{formatPrice(totalreturn)}}</p>
              </h3>
            </b-col>

          </b-row>
        </div>
      
         
       <table class="table table-striped borderd">
            <thead  class="bg-primary text-white">
              <tr>
                <th>رقم</th>
                <th>الاسم</th>
                <th>
                  الكمية
                </th>
               
                <th>السعر</th>
                <th v-if="ticket.invoiceTypeId==1">بعد التخفيض</th>
                <th>المجموع</th>
                <th v-if="ticket.invoiceTypeId==1"></th>
                <th v-if="ticket.invoiceTypeId==1">الترجيع</th>
                <th v-if="ticket.invoiceTypeId==1">المبلغ</th>
                
              </tr>
            </thead>
            <tbody >
              <tr  v-for="(sale,index)  in sales" :key="index" >
                <td >{{index+1}}</td>
                <td>{{ sale.itemname }}</td>        
                <td >{{sale.qyt}}                 
                  <font v-if="sale.returenQantity>0" size="4"> ({{sale.returenQantity}})</font>
                 </td>
                <td>{{formatPrice(sale.price)}}</td>
                <td v-if="ticket.invoiceTypeId==1">{{formatPrice(sale.price-sale.disAmount) }}</td>
                <td>{{formatPrice(sale.total)}}</td>
                <td v-if="ticket.invoiceTypeId==1">
                  <h3>{{sale.ruturnQuantity}}</h3></td>
                <td v-if="ticket.invoiceTypeId==1">
                  <b-button  @click="EditSaleQuantity(sale,'+')" size="sm" variant="success">+</b-button>
                  <b-button  @click="EditSaleQuantity(sale,'-')" size="sm" variant="success"> - </b-button>
                </td>
                <td v-if="ticket.invoiceTypeId==1">
                  {{formatPrice((sale.price-sale.disAmount) * sale.ruturnQuantity )  }}
                </td>
              </tr>
            </tbody>
          </table>

      </b-card>
      </template>
      </br>
      <div v-if="tickets.length>0" class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
          <b-card
               border-variant="danger"
               header-border-variant="danger"
               header-text-variant="danger"
               align="right" bg-variant="light" header="featured" 
               header-tag="header">
            <b-badge   slot="header"  variant="light">
              <h6>فواتير الترجيع السابقة</h6>
            </b-badge>
           

            </b-badge>
            <template  >
              <table class="table borderd">
                <thead  class="bg-primary text-white">
                  <tr>
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                  
                    <th>الوقت</th>
                    <th>فتح</th>
                   
                  </tr>
                </thead>
                <tbody >
                  <tr  v-for="(ticket,index)  in tickets" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{ticket.total}}</td>
                   
                    <td>
                      <vueDateFormat :format="format" :time="ticket.createdDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td>
                      <b-button  @click="OpenReverced(ticket)" size="sm" variant="success">
                        فتح
                      </b-button>
                    </td>
                   
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

<script src="./ReverseInvoiceCom.js"> </script>

<style>
</style>
