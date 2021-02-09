<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="Animeneytor.loginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="/Bootstrap/CSS/bootstrap.min.css">
    <link rel="stylesheet" type="text/css"  href="https://netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css">
    <link rel="stylesheet" href="CSS/login.css"/>
    <link rel="stylesheet" type="text/css" href="./CSS/DataTable/jquery.dataTables.min.css">

    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery-3.5.1.js"></script>
    <script type="text/javascript" charset="utf8" src="./JS/DataTable/jquery.dataTables.min.js"></script>    

     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/bootstrap.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/jquery-3.3.3.slim.min.js"></script>
     <script type="text/javascript" charset="utf8" src="/Bootstrap/JS/popper.min.js"></script>
     <script type="text/javascript" charset="utf8" src="JS/login.js"></script>
     <script type="text/javascript" charset="utf8" src="/JS/inicio.js"></script>        

    

</head>
<body>

    
    <div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
            <div class="col-lg-6 col-md-8 login-box">
                <div class="col-lg-12 login-key">
                    <i class="fa fa-key" aria-hidden="true"></i>
                </div>
                <div class="col-lg-12 login-title">
                    <img src="images/logo.png"  width="250px"/> 
                    <hr />
                    <span id="tilte">Iniciar Sesión</span>
                    <hr />
                </div>

                <div class="col-lg-12 login-form" id="formLogin" style="display:block">
                    <div class="col-lg-12 login-form">
                            <div class="form-group">
                                <label class="form-control-label">Correo</label>
                                <input type="text" id="txtCorreo" class="form-control" >
                                <div class="col-sm-12">
                                <small id="emailHelpLimpio" class="text-danger p-0" style="display:none">
                                  Este campo es requerido
                                </small>    
                                <small id="emailHelp" class="text-danger" style="display:none">
                                  Escribe un correo en un formato valido
                                </small>        
                              </div>
                            </div>
                            <div class="form-group">
                                <label class="form-control-label">Contraseña</label>
                                <input id="txtPass" type="password" class="form-control" >
                                <small id="passHelp" class="text-danger" style="display:none">
                                Este Campo es Requerido
                                </small>   
                            </div>

                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <!-- Error Message -->
                                </div>
                                <div class="col-lg-12 login-btm login-button">
                                    <div class="row w-100" >
                                        <div class="col-md-6">
                                            <button id="btnLogin" class="btn btn-outline-primary" style="width:144px;height:38px">Iniciar Sesión</button>                                        
                                        </div>
                                        <div class="col-md-6">
                                            <button class="btn btn-outline-primary" id="registerLink" style="width:144px;height:38px">Registrarse</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>

               <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////-->
                  <div id="formRegister" style="display:none" class="col-lg-12 login-form">
                    <div class="col-lg-12 login-form">
                            <div class="form-group">
                                <label class="form-control-label">Correo</label>
                                <input type="text" id="rtxtCorreo" class="form-control">
                                <div class="col-sm-12">
                                <small id="remailHelpLimpio" class="text-danger p-0" style="display:none">
                                  Este campo es requerido
                                </small>    
                                <small id="remailHelp" class="text-danger" style="display:none">
                                  Escribe un correo en un formato valido
                                </small>        
                              </div>
                            </div>
                           <div class="form-group">
                                <label class="form-control-label">Confirmar Correo</label>
                                <input type="text" id="txtCorreoConfirm" class="form-control">
                                <div class="col-sm-12">
                                <small id="emailConfirmHelpLimpio" class="text-danger p-0" style="display:none">
                                  Este campo es requerido
                                </small>    
                                <small id="emailConfirmHelp" class="text-danger" style="display:none">
                                  Escribe un correo en un formato valido
                                </small>    
                                <small id="emailSamemHelp" class="text-danger" style="display:none">
                                  Los correos no coinciden
                                </small>        
                              </div>
                            </div>
                            <div class="form-group">
                                <label class="form-control-label">Contraseña</label>
                                <input id="rtxtPass" type="password" class="form-control" i>
                                <small id="rpassHelp" class="text-danger" style="display:none">
                                Este Campo es Requerido
                                </small>   
                            </div>
                        <div class="form-group">
                                <label class="form-control-label">Confirmar Contraseña</label>
                                <input id="txtPassConfirm" type="password" class="form-control" i>
                                <small id="rpassConfirmHelp" class="text-danger" style="display:none">
                                Este Campo es Requerido
                                </small>
                                <small id="rpassSameHelp" class="text-danger" style="display:none">
                                Las contraseñas no son iguales
                                </small>   
                            </div>

                            <div class="col-lg-12 loginbttm">
                                <div class="col-lg-6 login-btm login-text">
                                    <!-- Error Message -->
                                </div>
                                <div class="col-lg-12 login-btm login-button">
                                    <div class="row w-100" >
                                        <div class="col-md-6">
                                            <button id="btnLoginLink" class="btn btn-outline-primary" style="width:144px;height:38px">Iniciar Sesión</button>                                        
                                        </div>
                                        <div class="col-md-6">
                                            <button id="btnRegister" class="btn btn-outline-primary"  style="width:144px;height:38px">Registrarse</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-2"></div>
            </div>
        </div>
</div>

     <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////-->
<div class="alert alert-success fade out" id="bsalertOk">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Correcto!</strong> Inicio de Sesion Correcto
</div>
<div class="alert alert-success fade out" id="bsalertRegOk">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Correcto!</strong> Registro Correcto
</div>
<div class="alert alert-danger fade out" id="bsalertError">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Error!</strong> Ocurrio un error intenta mas tarde
</div>

</body>
</html>
