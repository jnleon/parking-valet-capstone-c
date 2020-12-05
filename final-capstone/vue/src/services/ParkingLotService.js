import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
})

export default {

    getParkingSpots() {
        return http.get('/parkingSpot');
    }
}