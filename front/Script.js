function adicionar(){
    
    let nome = document.getElementById("nome").value
    let cpf = document.getElementById("cpf").value
    let numTelefone = document.getElementById("numTelefone").value

    enviar(nome, cpf, numTelefone)
}

function enviar(nome, cpf, numTelefone){
    let data = {
        "nome": nome,
        "cpf": cpf,
        "numTelefone": numTelefone
    }
    console.log(nome, cpf, numTelefone);
    fetch('https://localhost:7110/Api/Aluno/Adicionar',{
        method: 'POST',
        headers: {'Content-type': 'application/json; charset=UTF-8'},
        body: JSON.stringify(data)
    })
    .then(Response => Response.json())
    .then((result) => {
        alert("Aluno Cadastrado com Sucesso!!")
    })
    .catch((error) => {
        alert("Aluno Não foi Cadastrado!!")
        console.error(error);
    })
   
}

function ConsultarId(nome){

    fetch("https://localhost:7110/Api/Aluno/Consultar?IdAluno=1",{
        method: "GET",
        mode: "cors",
        headers:{
            'Content-Type': 'application/json'
        },
    }).then((Response) => Response.json())
    .then((result) => {
        alert("O Aluno",nome,"está matriculado!")
    })
    .catch((error) => {
        alert("Aluno Não foi encontrado!!")
    })
    
}
