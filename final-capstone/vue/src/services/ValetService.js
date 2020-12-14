import axios from 'axios';

export default {
    getAllTheInfo() {
        return axios.get("/valetslip/alldata")
    },
    checkLicensePlate(licensePlate) {
        return axios.get('/vehicle/' + licensePlate)
    }
 

}