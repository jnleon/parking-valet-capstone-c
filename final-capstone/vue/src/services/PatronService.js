import axios from 'axios';

export default {
    getValetSlip(slipId) {
        return axios.get("valetslip/ticket/"+ slipId)
    }
}