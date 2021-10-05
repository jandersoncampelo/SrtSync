# SrtSync - Sincronizador de Legendas
### Solução desenvolvida em C# e .NET 5
### A solução possui três projetos:
* **SrtSyncLib** - Biblioteca que faz a sincronia da legenda
* **SrtSyncConsole** - Para testes da biblioteca
* **SrtSyncTest** - Testes Unitários (**Não implementado**)
---
O formato SubRip (.srt) de arquivos de legendas para filmes se tornou bastante popular nos últimos anos, 
entre outros motivos por sua simplicidade. 
Segue breve explicação do formato...
Contêm linhas formatadas de texto simples em grupos separados por uma linha em branco. 
As legendas são numeradas sequencialmente, começando em 1. O código temporal (timecode) 
usado é horas:minutos:segundos,milissegundos com unidades de tempo fixadas em dois dígitos 
com preenchimento por zeros à esquerda, e frações fixadas em três dígitos também com preenchimento por
zeros à esquerda (00: 00: 00,000). 
O separador fracionário utilizado é a vírgula, uma vez que o programa foi escrito em França.

Exemplo de grupo:
---
```
168
00:20:41,150 --> 00:20:45,109
- How did he do that?
- Made him an offer he couldn't refuse.
```
---
Um problema comum enfrentado por usuários de legendas SubRip é a falta de sincronismo entre o áudio
e timecodes, que na maior parte das vezes pode ser resolvido aplicando-se um deslocamento fixo à
todos os timecodes da legenda.
O objetivo deste mini projeto é desenvolver uma biblioteca (.NET core class library) capaz de:
1. Parsear arquivos de legenda, permitindo sua leitura em memória de forma estruturada
2. Aplicar deslocamentos temporais (offset) à todos os timecodes de uma legenda
3. Salvar as legendas deslocadas em disco
