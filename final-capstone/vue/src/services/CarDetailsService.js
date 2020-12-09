import axios from 'axios';

export default {
    checkInCar(car) {
        return axios.post('/vehicle',car)
    }
}