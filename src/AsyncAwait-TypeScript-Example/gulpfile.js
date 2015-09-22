/// <binding Clean='clean' ProjectOpened='watch' />

var
    babel = require("gulp-babel"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    gulp = require("gulp"),
    mergeStream = require('merge-stream'),
    merge2 = require('merge2'),
    ngAnnotate = require("gulp-ng-annotate"),
    reporters = require("reporters"),
    rimraf = require("rimraf"),
    sourcemaps = require("gulp-sourcemaps"),
    tsc = require('gulp-typescript'),
    uglify = require("gulp-uglify");

var
    project = require("./project.json"),
    tsProject = tsc.createProject('tsconfig.json');

var polyfill = './node_modules/gulp-babel/node_modules/babel-core/browser-polyfill.js';

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);


gulp.task("copy:browser-polyfill", function() {
    gulp.src(polyfill).pipe(gulp.dest("./wwwroot/lib/babel"))
});

gulp.task("merge-tester", function () {
    merge2(gulp.src("./wwwroot/js/site.js"),
        gulp.src("./wwwroot/js/site.js")
        .pipe(sourcemaps.init())
        
        )
        .pipe(concat("merge-tester.js"))
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest("./wwwroot/js"));
});

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

    // the following merges the babel browser polyfill with the typescript output into one javascript file:

    merge2(
        gulp.src(polyfill),
        gulp.src(["./**/**.ts", "!node_modules/**/**.ts"])
		.pipe(sourcemaps.init())
		.pipe(tsc(tsProject, {}, reporters("gulp-typescript"))).js
		    .pipe(babel())            
    	    .pipe(ngAnnotate())
	    	)
    .pipe(sourcemaps.write("."))
    .pipe(concat("app.js"))
	.pipe(gulp.dest("./wwwroot/js"));

});

gulp.task("watch", ["compile:typescript"], function () {
    gulp.watch(["./**/**.ts", "!node_modules/**/**.ts"], ["compile:typescript"]).on("change", reportChange);
    //gulp.watch(paths.html, ["html", browserSync.reload]).on("change", reportChange);
    //gulp.watch(paths.mainHtml, ["bower", browserSync.reload]).on("change", reportChange);
    //gulp.watch(paths.sass.src, ["compile:sass", browserSync.reload]).on("change", reportChange);
});

function reportChange(event) {
    console.log("File " + event.path + " was " + event.type + ", running tasks...");
}