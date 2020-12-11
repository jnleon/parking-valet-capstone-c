<template>
  
</template>

<script>

import PatronService from "@/services/PatronService.js";

export default {
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
        }),
        //currentBalance = valetSlip.timeIn
    }
}
</script>

<style>

</style>