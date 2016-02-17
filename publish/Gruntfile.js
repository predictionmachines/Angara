/// <binding />
module.exports = function (grunt) {

    grunt.initConfig({     
        clean: ["./*.nupkg" ],
        nugetrestore: {
            all: {
                src: [
                    '../src/Angara.Base/packages.config',
                    '../src/Angara.Html/packages.config',
                    '../src/Angara.Reinstate/packages.config'
                ],
                dest: ['../ext/nuget']
            }
        },
        nugetPackFS: {
            "reinstate": "../src/Angara.Reinstate/Angara.Reinstate.fsproj",
            "html": "../src/Angara.Html/Angara.Html.fsproj",
            "base": "../src/Angara.Base/Angara.Base.fsproj"
        },
        nugetpush: {
            all: {
               src: '*.nupkg' 
            }
        }
    });

    grunt.loadNpmTasks('grunt-nuget');
    grunt.loadNpmTasks('grunt-contrib-clean');
        
    // Bug in current grunt-nuget doesn't allow to build .fsproj
    grunt.registerMultiTask('nugetPackFS', 'Create nuget package from .fsproj', function() {
       grunt.log.writeln("Creating package from " + this.data); 
       var executable = "node_modules/grunt-nuget/libs/nuget.exe"; // I assume that grunt-nuget 0.1.5 is installed
       var done = this.async();
       //invoke nuget.exe
       grunt.util.spawn({
           cmd: executable,
           args: [
               //specify the .nuspec file
               "pack",
               this.data,
 
               //specify where we want the package to be created
               "-OutputDirectory",
               ".",
 
               "-Build",
               "-IncludeReferencedProjects",
               "-Prop",
               "Configuration=Release"
           ] 
        }, function (error, result) {
            //output either result text or error message...
            if (error) {
                grunt.log.error(error);
            } else {
                grunt.log.write(result);
            }
            done();
        });
    });
    grunt.registerTask('default', ['clean','nugetrestore', 'nugetPackFS','nugetpush']);
};