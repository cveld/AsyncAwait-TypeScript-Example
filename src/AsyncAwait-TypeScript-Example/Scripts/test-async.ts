function test() {
    console.log("awaiter to be called...");
    awaiter();    
}


async function awaiter() {
    var result = await asyncfunc();
    console.log(result);
}

function asyncfunc() {
    
    var p = new Promise<string>((resolve, reject) => {
        setTimeout(() => {
            resolve('a string');
            console.log("resolved");
        }, 2000);
    });
    
    return p;
}