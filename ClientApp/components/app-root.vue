<template>
    <div id="app" class="container-fluid">
        <div class="row">
            <div v-if="logedin" class="col-sm-2">
                <nav-menu  params="route: route"></nav-menu>
            </div>
            <div  v-if="logedin" class="my_text col-sm-10">
                <router-view></router-view>
            </div>
          <div v-if="!logedin" class="col-sm-2">
            
          </div>
          <div v-if="!logedin" class="col-sm-10">
            <br></br>
            <b-form inline="">
            <label class="sr-only" for="inlineFormInputName2">user</label>
            <b-input v-model="userId" type="password" class="mb-2 mr-sm-2 mb-sm-0" id="inlineFormInputName2" placeholder="user" />

              
            <label class="sr-only" for="inlineFormInputGroupUsername2">pass</label>
            <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
              <b-input  v-model="password" type="password" id="inlineFormInputGroupUsername2" placeholder="pass" />
            </b-input-group>

            <b-button @click="Login()" variant="primary">Login</b-button>
          </b-form>
          </div>
        </div>
    </div>
</template>

<script src="./approotCom.js">
   
</script>

<style>
  .my_text
  {
  font-family:    Arial, Helvetica, sans-serif;

  }
</style>
