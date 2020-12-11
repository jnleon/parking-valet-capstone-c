<template>
  
  <div>
    <h3>Details of patron vehicle goes here</h3>
    <div id="formCheckInCar">
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="enterSlipNumber"
        label="Enter Velet Slip Number:"
        label-for="Enter Slip Number"
        description="Please enter the number on your valet slip."
      >
        <b-form-input
          id="patronValetSlip"
          v-model="valetSlip.Id"
          
          required
          placeholder="EnterValetSlip"
        ></b-form-input>
      </b-form-group>
      <b-button type="valetSlipSubmit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
    </div>
    
  </div>



  
</template>

<script>
export default {
  name: "valet-slip",
  //props: [checkedInCars],
  
    
    
  }
</script>

<style>

</style>

