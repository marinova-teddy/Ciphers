function encryption(msg, key) { // working
    let encMsg = "";
    let cols = key;
    let rows = Math.floor(msg.length/key) + 1;

    for (let i=0; i<cols; i++) {
        for (let j=0; j<rows; j++) {
            if ((i+key*j)>=msg.length) continue;
            encMsg+=msg[i+key*j];
        }
    }

    return encMsg;
} 

function decryption(encMsg, key) {
    let msg = "";
    let cols = Math.ceil(encMsg.length/key);
    let rows = key;

    for (let i=0; i<cols; i++) {
        for (let j=0; j<rows; j++) {
            if ((i+cols*j)>=encMsg.length) continue;
            msg+=encMsg[i+cols*j];
        }
    }

    return msg;
}

// test: encryption("It is also important that the work goes beyond.", 8)
// decryption("Isttrbtoa ke  nt yiithgosm eon pt edaohws.lrao ", 8)