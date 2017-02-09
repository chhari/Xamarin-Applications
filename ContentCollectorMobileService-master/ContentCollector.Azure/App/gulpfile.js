var gulp = require('gulp');
var less = require('gulp-less');
var browserSync = require('browser-sync').create();
var header = require('gulp-header');
var cleanCSS = require('gulp-clean-css');
var rename = require("gulp-rename");
var uglify = require('gulp-uglify');
var pkg = require('./package.json');
var wiredep = require('wiredep');
var inject = require('gulp-inject');
var concat = require('gulp-concat');
var jshint = require('gulp-jshint');
var stylish = require('jshint-stylish');
var jscs = require('gulp-jscs');
var ngAnnotate = require('gulp-ng-annotate');

// Set the banner content
var banner = ['/*!\n',
    ' * Start Bootstrap - <%= pkg.title %> v<%= pkg.version %> (<%= pkg.homepage %>)\n',
    ' * Copyright 2013-' + (new Date()).getFullYear(), ' <%= pkg.author %>\n',
    ' * Licensed under <%= pkg.license.type %> (<%= pkg.license.url %>)\n',
    ' */\n',
    ''
].join('');

// Compile LESS files from /less into /css
gulp.task('less', function() {
    return gulp.src('less/sb-admin-2.less')
        .pipe(less())
        .pipe(header(banner, { pkg: pkg }))
        .pipe(gulp.dest('./css'))
        .pipe(browserSync.reload({
            stream: true
        }))
});

// Minify compiled CSS
gulp.task('minify-css', ['less'], function() {
    return gulp.src('dist/css/sb-admin-2.css')
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./css'))
        .pipe(browserSync.reload({
            stream: true
        }))
});

// Copy JS to dist
gulp.task('js', function() {
    return gulp.src(['js/sb-admin-2.js'])
        .pipe(header(banner, { pkg: pkg }))
        .pipe(gulp.dest('dist/js'))
        .pipe(browserSync.reload({
            stream: true
        }))
})

// Minify JS
gulp.task('minify-js', ['js'], function() {
    return gulp.src('js/sb-admin-2.js')
        .pipe(uglify())
        .pipe(header(banner, { pkg: pkg }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('dist/js'))
        .pipe(browserSync.reload({
            stream: true
        }))
});


// Run everything
gulp.task('default', ['minify-css', 'minify-js', 'copy']);

// Configure the browserSync task
gulp.task('browserSync', function() {
    browserSync.init({
        server: {
            baseDir: ''
        },
    })
})


gulp.task('dev', ['browserSync', 'less', 'buildDev'], function() {
    gulp.watch('less/*.less', ['less', 'buildDev']);
    gulp.watch('css/*.css', ['buildDev']);
    gulp.watch('js/**/*.js', ['buildDev']);
    // Reloads the browser whenever HTML or JS files change
    gulp.watch('pages/*.html', browserSync.reload);
    gulp.watch('dist/js/*.js', browserSync.reload);
});

gulp.task('buildDev', ['less', 'style'],  buildDev);

function buildDev(){
    var target = gulp.src('./pages/index.html');
    var js = gulp.src(wiredep().js);
    var css = gulp.src(wiredep().css);

    return target
        .pipe(inject(js
            .pipe(gulp.dest('./dist/js')), {name: 'bower',  addRootSlash: false}
        ))
        .pipe(inject(gulp.src('js/**/*')
            .pipe(gulp.dest('./dist/js')), {addRootSlash: false}
        ))
        .pipe(inject(css
            .pipe(gulp.dest('./dist/css')), {name: 'bower', addRootSlash: false}
        ))
        .pipe(inject(gulp.src('css/**/*')
            .pipe(gulp.dest('./dist/css')), {addRootSlash: false}
        ))
        .pipe(gulp.dest('.'));
};

gulp.task('buildServeDev', ['buildDev'],  serve);

gulp.task('buildProd', ['less', 'style'], buildProd);

function buildProd(){
    var target = gulp.src('./pages/index.html');
    var js = gulp.src(wiredep().js);
    var css = gulp.src(wiredep().css);

    return target
        .pipe(inject(js.pipe(concat('bower.js'))
            .pipe(uglify())
            .pipe(rename({suffix: '.min'}))
            .pipe(gulp.dest('./dist/js')), {name: 'bower', addRootSlash: false}
            ))
        .pipe(inject(gulp.src('js/**/*')
            .pipe(ngAnnotate())
            .pipe(concat('app.js'))
            .pipe(uglify())
            .pipe(rename({suffix: '.min'}))
            .pipe(gulp.dest('./dist/js')), {addRootSlash: false}
        ))
        .pipe(inject(css
            .pipe(concat('bower.css'))
            .pipe(cleanCSS({ compatibility: 'ie8'}))
            .pipe(rename({suffix: '.min'}))
            .pipe(gulp.dest('./dist/css')), {name: 'bower', addRootSlash: false}
            ))
        .pipe(inject(gulp.src('css/**/*')
            .pipe(concat('app.css'))
            .pipe(cleanCSS({compatibility: 'ie8'}))
            .pipe(rename({suffix: '.min'}))
            .pipe(gulp.dest('./dist/css')), {addRootSlash: false}
        ))
        .pipe(gulp.dest('.'));
}

gulp.task('buildServeProd', ['buildProd'], serve);

gulp.task('serve', serve);

function serve(){
    browserSync.init({
        server: {
            baseDir: ''
        },
    })
}

gulp.task('style', jsStyle);

function jsStyle(){
 return gulp.src('js/**/*.js')
     .pipe(jshint())
     .pipe(jshint.reporter(stylish, {verbose: true}))
     .pipe(jscs());
}
