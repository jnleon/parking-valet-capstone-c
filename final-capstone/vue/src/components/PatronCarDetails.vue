<template>
<div>
 <h3>Hello</h3>
</div>
</template>

<script>

import PatronService from "@/services/PatronService.js";

export default {
    name: 'patron-car-details',
    currentBalance: '',
    props: ['slipId'],
    data() {
        return {
            valetSlip: {}
        }
    },
    
    created() {
        PatronService.getValetSlip(this.slipId).then((response) => {
            this.valetSlip=response.data;
            alert(this.valetSlip)
        });
        //currentBalance = valetSlip.timeIn
    },
    methods: {
        currentTime() {
        var today = new Date();
        var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var dateTime = date+' '+time;
        return dateTime;
      },
    },
}
</script>

<style>

</style>