function encryption(msg, key) {
    let encMsg = "";
    let cols = key;
    let rows = Math.floor(msg.length/key) + 1;

    for (let i=0; i<cols; i++) {
        for (let j=0;j<rows; j++) {
            if ((j*cols+i)<msg.length)
                encMsg+=msg[j*cols+i];
        }
    }
    return encMsg;
} 

function decryption(encMsg, key) {
    let decMsg = "";
    let cols = Math.floor(encMsg.length/key) + 1;
    let rows = key;
    let k = encMsg.length - (cols-1)*rows;
    let n = 0;

    for (let i=0; i<cols; i++) {
        for (let j=0; j<rows; j++) {
            if (j<k) decMsg+=encMsg[j*cols+i];
            else if (i+1!=cols) decMsg+=encMsg[j*cols+i-j+k];
        }
    }

    return decMsg;
}