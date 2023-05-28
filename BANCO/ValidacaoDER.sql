select * from aluno;
insert into aluno ( Nome, CPF, NumTelefone) values
('ERIK', 909090909, 9090909090);

select * from aula;
insert into aula (Descricao, QtdAlunos, Horario, Aluno_Id, Instrutor_Id) values
('Aula de Luta', 10, '20hrs', 1, 1);

select * from instrutor;
insert into instrutor ( Nome, CPF) values
('LUCAS', 909090909);

select * from plano;
insert into plano (IdPlano, Nome) values
(1,'PLUS');