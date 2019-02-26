$pkg_name="cmfg-habitat-web"
$pkg_origin="FAKEACCOUNT"
$pkg_version="0.2.0"
# $pkg_upstream_url="https://github.com/mwrock/habitat-aspnet-sample"
$pkg_maintainer="The Habitat Maintainers <humans@habitat.sh>"
$pkg_license=@('MIT')
$pkg_description="A sample ASP.NET Core app"

# $pkg_svc_run="cd $pkg_svc_var_path;dotnet ${pkg_name}.dll"
# $pkg_svc_run="cd C:\hab\studios\git-repos--buildit-habitatweb\hab\svc\cmfg-habitat-web\var;dotnet HabitatWeb.dll" #Working!
# $pkg_svc_run='cd "{{pkg.path}}/var";dotnet HabitatWeb.dll'

$pkg_deps=@("core/dotnet-core")
$pkg_build_deps=@("core/dotnet-core-sdk")

# $pkg_exports=@{
#     "port"="port"
# }

# $pkg_binds=@{
#   "database"="username password port"
# }

function Invoke-SetupEnvironment {
  Set-RuntimeEnv "HAB_CONFIG_PATH" $pkg_svc_config_path
}

function Invoke-Build {
  Copy-Item $PLAN_CONTEXT/../BuildITDotnetCore/* $HAB_CACHE_SRC_PATH/$pkg_dirname -recurse -force -Exclude ".vagrant"
  & "$(Get-HabPackagePath dotnet-core-sdk)\bin\dotnet.exe" restore
  & "$(Get-HabPackagePath dotnet-core-sdk)\bin\dotnet.exe" build
  if($LASTEXITCODE -ne 0) {
      Write-Error "dotnet build failed!"
  }
}

function Invoke-Install {
  & "$(Get-HabPackagePath dotnet-core-sdk)\bin\dotnet.exe" publish --output "$pkg_prefix/www"
}