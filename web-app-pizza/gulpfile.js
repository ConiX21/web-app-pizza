var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');


gulp.task('build', function () {
    gulp.src(
        [
            "node_modules/jquery/dist/jquery.min.js",
            "node_modules/bootstrap/dist/js/bootstrap.min.js"
        ])
        .pipe(gulp.dest("scripts"));

    gulp.src(
        [
            "node_modules/bootstrap/dist/css/bootstrap.min.css",
            "node_modules/animate.css/animate.min.css"
        ])
        .pipe(gulp.dest("content"));
});

gulp.task('less', function () {
    return gulp.src('./less/**/*.less')
        .pipe(less({
            paths: [path.join(__dirname, 'less', 'includes')]
        }))
        .pipe(gulp.dest('./content'));
});