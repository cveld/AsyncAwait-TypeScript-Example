function test() {
    console.log("async func2");
    awaiter();    
}


async function awaiter() {
    var q = await asyncfunc();
    console.log(q);
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