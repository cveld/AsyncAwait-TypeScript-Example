# AsyncAwait-TypeScript-Example
This project shows an example of how you can apply the async and await operations in a browser within a TypeScript based solution.
It utilises the babel transpiler to transpile the TypeScript ES6 output into browser compatible ES5 code.
The following components have been used:

* Visual Studio 2015; not required, but you get perfect syntax highlighting;
* ASP.NET 5 beta7 web project template;
* TypeScript 1.6; starting from version 1.6 it supports the experimental async and await operators. You will need to set ES6 as the target. TypeScript 1.6 does not support transpiling into ES5 of await/async yet, but transpiles into ES6 generator / yield code;
* Babel; a JavaScript transpiler;
* Gulp; a stream based JavaScript task runner;
* Babel Browser Polyfill; included in Babel; a JavaScript file that polyfills the Promise and regenerator objects (and more). 

The TypeScript example:
```typescript
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
```javascript
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

And the gulp task that copies over the Babel Browser Polyfill .js:
```javascript
var polyfill = './node_modules/gulp-babel/node_modules/babel-core/browser-polyfill.js';
gulp.task("copy:browser-polyfill", function() {
    gulp.src(polyfill).pipe(gulp.dest("./wwwroot/lib/babel"))
});
```
	
The modified tsconfig.json:
```json
{
  "compilerOptions": {
    "noImplicitAny": false,
    "noEmitOnError": true,
    "removeComments": false,
    "sourceMap": false,
    "target": "es6",
    "experimentalAsyncFunctions": true,
    "jsx": "react"
  },
  "exclude": [
    "node_modules",
    "wwwroot"
  ]
}
```