### Dependency Injection

- _Não é um padrão_ (Design Pattern)
- Técnica que _implementa_ o _IoC_
  - Inversion of Control (Inversão de Controle)
  - DIP
- Ajuda no baixo acoplamento
- Provê uma melhor divisão de responsabilidades
- O que preciso para trabalhar?
  - Quem vai me prover? Não importa

### Baixo acoplamento

- Imagina um sistema _grande_
- Cada pedacinho tem que _ focar em uma coisa_
  - _Não dá_ para abraçar o mundo
- Tem que funcionar de forma _independente_
  - Fácil de _entender_
  - Fácil de dar _manutenção_
  - Se precisar _jogar fora e criar outro_ é fácil

### Bad, bad, bad

- Vamos tomar como base um pedido
- Recebe os parametros
- Processa o pedido

### O problema

- _Dificil_ de ler
- _Dificil_ de mudar
- Código _não é reusável_
- _Alto acoplamento_
- _Testes_? Pra quê?

### Como resolvemos isto?
- *Orientação a Objetos*
    - *Abstração, encapsulamento*
        - *Simples* e direto
    - Pedaçoes *pequenos*
    - *Reusáveis*
    - *Testáveis*
    - *Legiveis*
    - *Facil* manutenção

### Cobre o pé... descobre a cabeça
- Está *bem melhor*, mas...
- A *dependencia* ainda existe
    - Só mudou de lugar
- Depende da *implementação*
    - Depende da *abstração*

### Inversion of Control
- *Inversão de Controle*
- *Externaliza* as responsabilidades
    - *Delega*
- *Cria uma dependencia* externa
    - O controller não é mais *responsavel* pelo cálculo do frete, agora ele *depende de um serviço*

### Cobre o pé... descobre a cabeça
- Implementação
    - *Concreto*
    - *Materialização*
    - É o *"Como"*
- Abstração
    - *Contrato*
    - Só as *definições*
    - É o *"O que"*
- Implementação
    - *Não varia*
    - *É uma visão, uma versão*
    - *Mais acoplado*
- Abstração
    - *Tem várias implementações*
    - *Menos acoplado*
