function testing(e) {
    e.preventDefault();
    const numOfTests = 50;

    for (let i=0;i<numOfTests;i++) {
        let msg = genMsg();
        let key = Math.floor(msg.length*(0.3 + Math.random()*0.16));
        genDiv(msg, decryption(encryption(msg, key), key), key, i+1);
    }
}

function genDiv(msg, decMsg, key, testNum) {
    let resultDiv = document.createElement("div");
    let header = document.createElement("h2");
    header.innerHTML = "Test #" + testNum;
    resultDiv.appendChild(header);

    let list = document.createElement("ul");
    let item1 = document.createElement("li");
    item1.innerHTML = "Test input: <em>" + msg + "</em>";
    let item2 = document.createElement("li");
    item2.innerHTML = "Test output: <em>" + decMsg + "</em>";
    let item3 = document.createElement("li");
    item3.innerHTML = "Key: <em>" + key + "</em>";
    let item4 = document.createElement("li");
    item4.innerHTML = "Comments: <em>" + (msg===decMsg) + "</em>";
    list.appendChild(item1);
    list.appendChild(item2);
    list.appendChild(item3);
    list.appendChild(item4);
    resultDiv.appendChild(list);

    document.getElementById("results").appendChild(resultDiv);
}

function genMsg() {
    let msg = "";
    //grab a sentence from somewhere
    msg = "It is also important that the work goes beyond.";
    return msg;
}