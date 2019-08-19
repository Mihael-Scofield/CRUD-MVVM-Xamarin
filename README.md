# Aplicativo de Cadastramento de Clientes (MVVM)
Um aplicativo para android implementado em C# e Xamarin.Forms capaz de cadastrar, ler, atualizar e deletar clientes utilizando SQLite para isso.

Implementado por Mihael Scofield de Azevedo.

## Instalação
Abra a solução "cadastramento.sln" no Visual Studio, então conecte seu celular com o computador em modo de depuração e faça o Deploy pelo Visual Studio.

## Execução
O programa é capaz de fazer inserção (cadastramento), busca, exclusão, ordenação da listagem de clientes dentro de um banco de dados SQLite.
Com um layout de menus intuitivos e simples, foi pensado para usuários do dia-a-dia, "conversando" com quem o utiliza.

## Estruturação
O modelo MVVM foi adotado para esse projeto, focando e buscando a maior modularização possível.

### Divisão de Funções
O programa foi implementado em 6 folders diferentes

  - Helpers 
  
  Contendo funções básicas para fazer a manipulação do Banco de Dados.
  
  - Icons
  
  Folder básico que possui alguns ícones utilizados no projeto.
   
  - Models
  
  Aqui estão os objetos e as classes referentes aos dados utilizados.
  
  - Services
   
   Contendo algumas interfaces, juntamente a implementações, de serviços basicos como navegar pelas páginas e mostrar mensagens na tela.
   
   - ViewModels
   
   Aqui está toda a lógica do trabalho. Conversando com a View, fazendo as chamadas das funções para manipular o Model e notificando a View após as alterações.
   Todos os Bindings estão aqui
   
   - Views
   
   Aqui está a UI do programa e apenas isso, reaproveitando alguns códigos e se dividindo em 3 paginas, lista, cadastramento e edição.
   
