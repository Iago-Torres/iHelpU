import React from "react";

function Login() {
    return (
        <div className='login template d-flex justify-content-center align-items-center w-100 vh-100 bg-primary'>
            <div className="w-40 p-5 rounded bg-light">
                <form>
                    <h3>Sign In</h3>
                    <div className="mb-2">
                        <label htmlFor="email">Email</label>
                        <input type="email" placeholder="Digite seu email" className="form-control" />
                    </div>
                    <div className="mb-2">
                        <label htmlFor="password">Password</label>
                        <input type="password" placeholder="Digite sua senha" className="form-control" />
                    </div>
                    <div>
                        <input type="checkbox" className='custom-control custom-checkbox' id="check" />
                        <label htmlFor="check" className="custom-input-label">
                            Lembrar Dispositivo
                        </label>
                    </div>
                    <div className="d-grid">
                        <button className='btn btn-primary'>Entrar</button> {/* Ajuste no texto do botão */}
                    </div>
                    <p className="text-right">
                        Esqueci a <a href="#">senha?</a> | <a href="#">Sign Up</a> {/* Corrigido o href */}
                    </p>
                </form>
            </div>
        </div>
    );
}

export default Login;
