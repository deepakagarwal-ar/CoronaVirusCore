/// <binding AfterBuild='default' />
var gulp = require('gulp');
var uglify = require("gulp-uglify");
var concat = require("gulp-concat");

gulp.task("minify", function () {
    return gulp.src("wwwroot/js/**/*.js")
        .pipe(uglify())
        .pipe(concat("gallery.min.js"))
        .pipe(gulp.dest("wwwroot/dist"));
});

gulp.task('default', gulp.series(['minify'], function (done) {
    done();
}));