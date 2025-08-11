ARQUITETURA DO PROJETO E INTEGRAÇÃO



Projeto: Sistema de Integração  
Modelo de Arquitetura em Três Camadas

Camada de Apresentação (Front-end):


+---------------------+
|    SI Front-end     |
+---------------------+
           |
           v
Camada de Lógica (Back-end):
+---------------------+         +----------------------+
|    SI Back-end      |<------->|  Banco da BL (SI)    |
+---------------------+         +----------------------+

           ^
           |
           |
+---------------------+         
|        MVC          |<---------------------------+
+---------------------+                            |
           |                                       |
           v                                       |
+---------------------+                            |
| Banco do MVC (local)|                            |
+---------------------+                            |
                                                   |
                                                   |
+---------------------+                            |
|     API Pública     |<---------------------------+
+---------------------+

Legenda:
- SI Front-end: Interface visual do sistema de integração
- SI Back-end: Camada lógica da aplicação (API interna)
- MVC: Aplicação monolítica que consome a API e possui banco próprio
- API Pública: Interface externa exposta pela aplicação
- Banco da BL: Banco da lógica de negócio
- Banco do MVC: Banco próprio do sistema MVC
