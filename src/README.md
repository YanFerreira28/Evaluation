RODAR MIGRATIONS LOCAL:
1. COPIAR O CAMINHO DO PROJETO Ambev.DeveloperEvaluation.ORM
2. EXECUTAR O COMANDO dotnet tool install --global dotnet-ef CASO O DOTNET-EF NÃO ESTEJA INSTALADO
3. RODAR O COMANDO ABAIXO NO CONSOLE:
dotnet ef database update --project "COLE AQUI O CAMINHO COPIADO NA ETAPA 2" --startup-project "COLE AQUI O CAMINHO COPIADO NA ETAPA 2"



FLUXO:
VISTO QUE EM UM FLUXO DE VENDAS NÃO É BOA PRÁTICA EXCLUIR UM REGISTRO DEPOIS DE CRIADO FORAM FEITAS AS SEGUINTES IMPLEMENTAÇÕES:
- ENDPOINT CRIAR VENDA
- CANCELAR VENDA
- CONSULTAR VENDA ESPECIFICA
- CONSULTAR TODAS.
- CANCELAR ITEM (AO CANCELAR UM ITEM O VALOR TOTAL DA VENDA É ATUALIZADO)
- EDITAR VENDA

DESENVOLVIMENTO FOI FEITO SEGUINDO AS ORIENTAÇÕES DO README, O FLUXOGRAMA E ALGUMAS REGRAS DE NEGÓCIO FOI INTRODUZIDAS POR SENSO ANALITICO JÁ QUE NÃO ESTAVA DESCRITO NO DOCUMENTO, CASO SEJA FEITA ALGUMA OBSERVAÇÃO POSSO ADEQUAR.

ABAIXO IREI MOSTRAR O FUNCIONAMENTO DE ALGUNS DOS ENDPOINTS

CRIAÇÃO DE VENDA:

![image](https://github.com/user-attachments/assets/cd5a3275-f661-42cf-bca9-42b5fc45a877)

CRIAÇÃO DE VENDA COM DESCONTO 10%:

![image](https://github.com/user-attachments/assets/c43ec060-7c09-4a1c-96f4-d6e9cf4aadfa)

CRIAÇÃO DE VENDA COM DESCONTO 20%:

![image](https://github.com/user-attachments/assets/012bdc1b-6a26-489c-bad4-9c0be0c7385a)

TENTATIVA DE CRIAÇÃO DE VENDA COM MAIS DE 20 QUANTIDADES DO MESMO PRODUTO:

![image](https://github.com/user-attachments/assets/9490cddb-b0c8-4187-8e65-693c6d83caa0)

CONSULTA DE VENDA:

![image](https://github.com/user-attachments/assets/317d7990-e382-4881-a8a6-7c2192bf201a)

CONSULTA TODAS VENDAS:

![image](https://github.com/user-attachments/assets/69f7de4d-0300-4e54-aaf5-efc099131777)

CANCELAR VENDA:

![image](https://github.com/user-attachments/assets/f34871ee-4095-4f62-9797-f8c7997c3bda)
![image](https://github.com/user-attachments/assets/d2613f1b-9d8f-4e44-958e-d03b31db8c67)

CANCELAR ITEM DE UMA VENDA:

![image](https://github.com/user-attachments/assets/319f941b-3223-44da-ac15-a69b0b7d19d8)
![image](https://github.com/user-attachments/assets/4244bc6f-f637-447d-9413-ec7b4f0e9f72)


TESTES DE UNIDADE:

![image](https://github.com/user-attachments/assets/2814579a-d511-42c0-b1c6-07a8d4734f8b)






