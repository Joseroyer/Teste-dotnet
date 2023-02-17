# Teste-dotnet

 ### Em **appsettings.json**: Colocar o nome do servidor em **DefaultConnection**!
    "ConnectionStrings": {
      "DefaultConnection": "NOME_DO_SERVIDOR;database=DirectData;trusted_connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"
    }
    
    
 ### Em Console do Gerenciador de Pacotes, inserir no console para o **Migration**:
  * Add-Migration "Teste" - Adicionar o migration.
  * Update-database - Subir para o DB.
  * Para remover o migration:
     1. Update-Database -Migration 0
     2. Remove-Migration - Remove o migration.
  
  
 
   
