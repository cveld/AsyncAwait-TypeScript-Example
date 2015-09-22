# AsyncAwait-TypeScript-Example
This project shows an example of how you can apply the async and await operations in a browser within a TypeScript based solution.
It utilises the babel transpiler to transpile the TypeScript ES6 output into browser compatible ES5 code.
The following components have been used:
* Visual Studio 2015; not required, but you get perfect syntax highlighting;
* ASP.NET 5 beta7 web project template;
* TypeScript 1.6; starting from version 1.6 it supports the experimental async and await operators;
* Babel; a JavaScript transpiler;
* Gulp; a stream based JavaScript task runner;
* Babel Browser Polyfill; included in Babel; a JavaScript file that polyfills the Promise and regenerator objects (and more). 

The TypeScript example:
```
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
```

The Gulp task that is responsible for processing the .ts-file towards an ES5-compabile .js-file:
```
gulp.task("compile:typescript", function () {
  var tsResult =
    gulp.src(["./**/**.ts", "!node_modules/**/**.ts"])
        .pipe(sourcemaps.init())
        .pipe(tsc(tsProject));

	tsResult.js
		    .pipe(babel())            
    	    .pipe(ngAnnotate())
            .pipe(concat("app.js"))
	    	.pipe(sourcemaps.write("."))
	.pipe(gulp.dest("./wwwroot/js"));
	return;
});
```
	
