import axios from "axios";
import exec from 'child_process'; 

function execute(command, callback){
    exec(command, function(error, stdout, stderr){ callback(stdout); });
};

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

execute('minikube service request-service --url', async function(ip) {
    const testAmount = 5;
    const requestsAmount = 100;
    const route = ip.substring(0, ip.length - 1) + "/api/requests/with-advert/1"; 
    for (let i = 0; i < testAmount; i++) {
        await sendRequestsTest(route, requestsAmount);
    }
})  
