

<template>
  <div>
    </br>
    <b-card bg-variant="info" no-body="">
      <b-tabs  pills="" no-nav-style=""	card="">
        <b-tab size="5" title="المبيعات" active="" @click="GetSelesInvoices" >
          <b-card bg-variant="light" border-variant="Primary"
              header="Primary"
              header-tag="header"
              header-border-variant="Primary"
              align="right" >
            <b-pagination align="center" size="md" :total-rows="total" v-model="currentPage" :per-page="pageSize">
            </b-pagination>
            <template  >
              <table  class="table table-bordered  table-striped ">
                <thead  class="bg-primary text-white">
                  <tr align="center" >
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                    <th> التخفيض</th>
                    <th>طريقة الدفع</th>
                    <th>المستخدم</th>
                    <th>وقت الفتح</th>
                    <th>وقت الأنهاء</th>

                    <th>فتح</th>
                  </tr>
                </thead>
                <tbody >
                  <tr align="center"  v-for="(ticket,index)  in selesInvoices" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{ticket.total}}</td>
                    <td>{{ticket.dis}}</td>
                    <td>{{ticket.paymentDes}}</td>
                    <td>{{ticket.user}}</td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.createdDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.time" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
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

            <div dir="rtl"  slot="header"   class="row">
              <div class="col-sm-6 input-group">
                <datepicker v-model="datesalesInvoices" @closed="GetSelesInvoices()" ></datepicker>


              </div>
              <div class="col-sm-6">

              </div>
            </div>

          </b-card>
        </b-tab>
        <b-tab title="الترجيعات" @click="GetReturnInvoices">
          <b-card bg-variant="light" border-variant="danger"
             header="Danger"
           header-tag="header"
             header-border-variant="danger"
             align="right" >

            <b-pagination align="center" size="md" :total-rows="total" v-model="currentPage" :per-page="pageSize">
            </b-pagination>
            <template  >
              <table class="table table-bordered  table-striped ">
                <thead  class="bg-primary text-white">
                  <tr align="center">
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                    <th> التخفيض</th>
                    <th>طريقة الدفع</th>
                    <th>المستخدم</th>
                    <th>وقت الفتح</th>
                    <th>وقت الأنهاء</th>
                    <th > فاتورة</th>
                    <th>فتح</th>
                  </tr>
                </thead>
                <tbody >
                  <tr align="center"  v-for="(ticket,index)  in selesInvoices" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{ticket.total}}</td>
                    <td>{{ticket.dis}}</td>
                    <td>{{ticket.paymentDes}}</td>
                    <td>{{ticket.user}}</td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.createdDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.time" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td >{{ticket.parentId}}</td>
                    <td>
                      <b-button  @click="OpenReverced(ticket)" size="sm" variant="success">
                        فتح
                      </b-button>
                    </td>

                  </tr>
                </tbody>
              </table>
            
            </template>

            <div dir="rtl"  slot="header"   class="row">
              <div class="col-sm-6 input-group">
                <datepicker v-model="datesalesInvoices" @closed="GetSelesInvoices()" ></datepicker>


              </div>
              <div class="col-sm-6">

              </div>
            </div>

          </b-card>
        </b-tab>
        <b-tab title="المعلقة" @click="GetSuspendedInvoice">
          <b-card bg-variant="light" border-variant="danger"
             header="Danger"
           header-tag="header"
             header-border-variant="danger"
             align="right" >

            <b-pagination align="center" size="md" :total-rows="total" v-model="currentPage" :per-page="pageSize">
            </b-pagination>
            <template  >
              <table class="table table-bordered  table-striped ">
                <thead  class="bg-primary text-white">
                  <tr align="center">
                    <th>رقم الفاتورة</th>
                    <th>الأجمالي</th>
                    <th> التخفيض</th>
                    <th>طريقة الدفع</th>
                    <th>المستخدم</th>
                    <th>وقت الفتح</th>
                    <th>وقت التعليق</th>
                  
                    <th>فتح</th>
                  </tr>
                </thead>
                <tbody >
                  <tr align="center" v-for="(ticket,index)  in selesInvoices" :key="index" >
                    <td>{{ticket.invoiceId}}</td>
                    <td>{{ticket.total}}</td>
                    <td>{{ticket.dis}}</td>
                    <td>{{ticket.paymentDes}}</td>
                    <td>{{ticket.user}}</td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.createdDate" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
                    </td>
                    <td>
                      <vueDateFormat :format="format" :time="ticket.time" :type="type" :autoUpdate="autoUpdate"></vueDateFormat>
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

            <div dir="rtl"  slot="header"   class="row">
              <div class="col-sm-6 input-group">
                <datepicker v-model="datesalesInvoices" @closed="GetSelesInvoices()" ></datepicker>


              </div>
              <div class="col-sm-6">

              </div>
            </div>

          </b-card>
        </b-tab>
      </b-tabs>
    </b-card>


  </div>

<!--<div class="row"> 
    </br>
    <div class="col-sm-12">
      </br>
     
      
    </div>
   


  </div>--> 
</template>

<script src="./homeComjs.js">

</script>

<style>
</style>
