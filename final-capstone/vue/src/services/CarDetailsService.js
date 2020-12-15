import axios from 'axios';

export default {
    checkInCar(car) {
        return axios.post('/vehicle',car)
    },
    changeParkingSpotStatus(slipId) {
        return axios.put(`/valetslip/requestPickupVehicle/${slipId}`)
    }
}