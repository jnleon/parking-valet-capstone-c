import axios from 'axios';

export default {
    getValetSlip(valetSlip) {
        return axios.get('valetslip/ticket/{id}', valetSlip)
    }
}