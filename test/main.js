import axios from "axios";

async function sendRequestsTest(route, count) {
    let failed = 0;
    let time = 0;
    for (let i = 0; i < count; i++) {
        const start = performance.now();
        try {
            await axios.get(route);
        } catch (error) {
            failed++;
            console.log(`ERROR: attempt: ${i} status: ${error.response?.status}`)
        }
        time += Number((performance.now() - start) / 1000);
    }
    console.log(`average duration: ${(time / count).toFixed(3)}`);
    console.log(`${failed} from ${count} failed\n`);
}

const testAmount = 5;
const requestsAmount = 100;
const route = "http://localhost/api/requests/with-advert/1"; 
for (let i = 0; i < testAmount; i++) {
    await sendRequestsTest(route, requestsAmount);
} 
