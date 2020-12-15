import axios from 'axios';

export default {
    getAllTheInfo() {
        return axios.get("/valetslip/alldata")
    },
    checkLicensePlate(licensePlate) {
        return axios.get('/vehicle/' + licensePlate)
    },
    getListOfRequestedCars() {
        return axios.get("/valetslip/alldatapickuprequested")
    },
    updateParkingSpot(ticketId,spotId) {
        return axios.put(`/valetslip/parkvehicle/ticket/${ticketId}/spot/${spotId}`)
    }
 

}