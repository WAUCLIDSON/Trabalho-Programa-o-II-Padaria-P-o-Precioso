# Trabalho Programação II Padaria Pão Precioso

Projeto Padaria Pão Precioso
O projeto do Sistema de Gestão da Padaria Pão Precioso foi criado para organizar e facilitar o dia a dia de uma padaria, trazendo eficiência e controle sobre diversos aspectos do negócio. Vamos explorar, de forma interativa, como cada funcionalidade contribui para a operação do estabelecimento.

O que acontece ao iniciar o sistema? Quando o programa é concluído, ele exibe um menu principal bem organizado, com opções que representam as áreas centrais da padaria. Este menu oferece acesso direto a funções como atendimento, estoque, inventário, caixa e gestão de vendas.
O design é pensado para ser simples e direto, evitando complicações p

Atendimento: Cuidando dos clientes A funcionalidade de atendimento é dividida em submenus para diferentes cenários:
No Caixa : Aqui, você registra vendas diretas. O sistema permite que o operador escolha os produtos pelo nome ou ID, adicione detalhes e finalize com a escolha de pagamento. O estoque é atualizado automaticamente, garantindo que você sempre saiba o que está disponível. Na Lanchonete : Para pedidos ou pedidos, os produtos são acrescentados a uma lista específica do cliente. É ideal para quem consome no local e paga ao final. Consulta de Pedidos : Caso um cliente queira saber o status de um pedido ou pedido, você pode localizar facilmente pelo nome ou ID. Por que isso é útil? Porque melhora a experiência do cliente ao agilizar o atendimento e evita erros, como esquecimentos ou confusões no pedido.

Controle de Estoque: Garantindo que nada falte Manter o estoque sob controle é vital para qualquer padaria. Essa funcionalidade ajuda você a:
identificar que produtos estão em estoque mínimo . Localizar itens que estão vencidos ou próximos da validade. Detectar rupturas de estoque, ou seja, produtos esgotados. O sistema alerta sobre esses pontos críticos, permitindo que decisões sejam tomadas rapidamente, como encomendar mais produtos ou promover vendas para evitar perdas.

Reposição de Produtos: Organização e previsibilidade Essa é a palavra chave

Entrada de Produtos de Fornecedores Ao receber mercadorias, é necessário atualizar o sistema para refletir o estoque real. Essa funcionalidade permite:

Selecionar o produto recebido. Informar a quantidade entregue pelo fornecedor. Atualizar o estoque automaticamente. Com isso, o controle de inventário fica sempre preciso, evitando discrepâncias entre o que o sistema mostra e o que realmente está disponível.


Gestão de Caixa: O coração financeiro Essa parte do sistema é dedicada a monitorar o dinheiro que entra e sai da padaria:
Entradas : Valores recebidos de vendas são registrados, separados por método de pagamento (dinheiro ou cartão). Saídas : Despesas, como pagamento de fornecedores ou troco, podem ser marcas registradas. Relatórios : O sistema gera relatórios detalhados de entradas e saídas, além de permitir o monitoramento do saldo atual. Alertas são emitidos se o saldo estiver abaixo de um limite seguro. Por que isso é importante? Porque ajuda você a manter o controle financeiro e tomar decisões com base em dados confiáveis.


Inventário: Ajustes e revisões periódicas A gestão de inventário permite que você abra contagens, registre os números físicos e compare com o estoque do sistema. Diferenças são destacadas, mostrando onde pode haver problemas, como perdas ou furtos.


Produtos: Tudo sobre o que vendemos Essa funcionalidade dá acesso a um banco de dados com todos os produtos da padaria:


Listar produtos existentes. Adicione novos itens ao catálogo. Excluir produtos descontinuados. Além disso, você pode buscar produtos específicos para ver informações detalhadas, como quantidade em estoque, validade e preço.


Relatórios: Para decisões baseadas em dados O sistema é capaz de gerar diversos relatórios:
Relatório de Vendas por Período : Mostra o desempenho em determinados dias ou semanas. Relatório de Estoque Detalhado : Traz o valor total dos produtos por categoria, ajudando a avaliar o capital investido. Extrato Geral de Comandos e Pedidos : Dá uma visão abrangente de tudo o que foi vendido. Esses relatórios são salvos automaticamente, permitindo consultas futuras e até auditorias.


Venda para Festas: Mais que uma padaria comum Essa função é perfeita para atender pedidos maiores, como bolos e cestas para eventos. Ela segue o mesmo princípio das vendas comuns, mas com foco em encomendas personalizadas. Após o registro, os pedidos são adicionados ao fluxo financeiro e ao histórico de vendas.
Por que o sistema é especial? Cada função foi projetada para atender às demandas reais de uma padaria, com atenção aos detalhes e foco na eficiência. Ele combina tecnologia e praticidade, ajuda


Economizar tempo : Automatizando tarefas manuais. Reduzir erros : Atualizações automáticas evitam esquecimentos e confusões. Tomar melhores decisões : Relatórios detalhados oferecem insights valiosos. Pão Precioso não é apenas um sistema de gestão. É uma ferramenta para transformar o dia a dia


#Aqui está uma análise detalhada de cada funcionalidade no projeto.....



Fluxo de aplicação principal MainMétodo: Iniciando o Sistema Objetivo : O sistema inicia a execução aqui instanciando um Padariaobjeto (Bakery) e chamando o IniciarSistema()método. Por quê? Isso centraliza o fluxo de controle, garantindo que tudo esteja configurado corretamente antes que o usuário interaja com o aplicativo. Funcionalidades principais do sistema


Gestão de Serviços ( SubmenuAtendimento) Principais características : Atendimento na Caixa: Lida com vendas na loja no caixa. Atendimento na Lanchonete : Atende pedidos de clientes gastronômicos. Consultar Pedido ou Comanda : Permite consultar detalhes de pedidos ou fichas de clientes. Objetivo : Simplifica as interações com os clientes e o processamento de pedidos, melhorando a eficiência e a satisfação do cliente.
Pesquisa de produtos ( BuscarProduto) Recurso principal : permite que os usuários pesquisem um produto usando seu ID ou nome. Objetivo : Localizar rapidamente o produto d
Controle de Estoque ( ControleDeEstoque) Principais características : Identifica produtos com baixos níveis de estoque. Destaca produtos vencidos ou prestes a vencer. Lista itens fora de estoque. Objetivo : Ajuda a manter a saúde do estoque, evitando rupturas e desperdícios.
Entrada do produto do fornecedor ( EntradaDeProdutos) Recurso principal : atualiza o inventário quando chega novo estoque. Objetivo : Garante a manutenção de níveis de estoque precisos
Gestão de caixa ( GestaoDeCaixa) Principais características : Monitora entradas de caixa (por exemplo, receita de vendas) e saídas (por exemplo, pagamentos de fornecedores). Gera relatórios financeiros detalhados. Objetivo : Fornece transparência financeira e ajuda a monitorar atividades monetárias diárias.
Gestão de produtos ( SubmenuProdutos) Principais características : Liste todos os produtos com informações detalhadas. Adicionar novos produtos Remova produtos descontinuados. Objetivo : Mantém o catálogo de produtos atualizado, garantindo que somente os itens disponíveis sejam exibidos durante as transações.
Gestão de Estoque ( SubmenuInventario) Principais características : Inicia a contagem de estoque. Registra discrepâncias entre o estoque esperado e o real. Objetivo : Garante que o inventário físico corresponda aos dados registrados, minimizando roubos ou perdas.
Relatórios de vendas ( RelatorioVendasPorPeriodo) Recurso principal : Gera um relatório de vendas dentro de um período especificado. Objetivo : Ajuda a analisar tendências de vendas e identificar
Pedidos de eventos ( VendaDePedidosParaFestas) Principais características : Registra grandes pedidos para eventos. Rastreia produtos vendidos para esses pedidos e atualiza o estoque. Objetivo : Atender às necessidades especiais dos clientes, aprimorando as ofertas de serviços.
Reposição de estoque ( ReposicaoDeProdutos) Recurso principal : lista produtos que precisam de reposição com base nos níveis mínimos de estoque. Objetivo : Garante um fornecimento contínuo de itens essenciais. Estruturas de Dados e Classes de Suporte Produto(Produto) Classe Finalidade : Representa um produto individual com detalhes como nome, categoria, preço, nível de estoque e data de validade. Uso : Usado em controle de estoque, vendas e relatórios. Pedido(Ordem) Classe Objetivo : Rastreia pedidos de clientes, incluindo produtos e quantidades. Uso : Usado SubmenuAtendimentopara gerenciar pedidos e guias. Caixa(Caixa registradora) Classe Objetivo : Gerenciar as operações financeiras da padaria, incluindo o rastreamento de receitas e despesas. Uso : essencial para transparência financeira e geração de relatórios de fluxo de caixa. Venda(Venda) Classe Finalidade : Registra detalhes de cada venda, incluindo os produtos vendidos e o valor total. Uso : Fornece dados para relatórios e análises de fluxo de caixa. Fluxo de trabalho do sistema Inicialização ( CarregarProdutos) : pré-carrega um catálogo de produtos em Interação do usuário : O menu principal orienta os usuários a selecionar as operações, tornando o sistema intuitivo e fácil de usar. Gerenciamento de dados : garante inventário preciso, rastreamento financeiro e tratamento de pedidos.





using System; 
using System.Collections.Generic; 
using System.IO; 
using System.Linq;

 namespace PadariaPaoPrecioso
 { 
    public class Program
    { 
       static void Main(string[] args) 
       { 
Padaria padaria = new Padaria();          padaria.IniciarSistema(); 
} 
}

public class Padaria
{
    private List<Produto> Produtos;
    private Dictionary<string, List<Pedido>> Comandas;
    private Caixa Caixa;
    private List<Venda> Vendas;
    private Dictionary<int, int> ContagemInventario;
    private int quantidade;

    public Padaria()
    {
        Produtos = new List<Produto>();
        Comandas = new Dictionary<string, List<Pedido>>();
        Caixa = new Caixa();
        Vendas = new List<Venda>();
        ContagemInventario = new Dictionary<int, int>();
        CarregarProdutos();
    }

    public void IniciarSistema()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ============================================= ");
            Console.WriteLine("         PADARIA PÃO PRECIOSO      ");
            Console.WriteLine("       Para nós o Pão é Sagrado.   ");
            Console.WriteLine("    =============================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1.Atendimento");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Buscar Produto");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3. Controle de Estoque");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("4. Entrada de Produtos de Fornecedores");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("5. Gestão de Caixa");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("6. Gestão de Inventário");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("7. Nossos Produtos");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("8. Reposição de Produtos");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("9. Venda de Pedidos para Produção de Festas");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("10. Sair");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         Um Sistema WAD Sistemas");
            Console.ResetColor();
            Console.Write("             Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida.Tente novamente.");
                Console.ResetColor();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    SubmenuAtendimento();
                    break;
                case 2:
                    BuscarProduto();
                    break;
                case 3:
                    ControleDeEstoque();
                    break;
                case 4:
                    EntradaDeProdutos();
                    break;
                case 5:
                    GestaoDeCaixa();
                    break;
                case 6:
                    SubmenuInventario();
                    break;
                case 7:
                    SubmenuProdutos();
                    break;
                case 8:
                    ReposicaoDeProdutos();
                    break;
                case 9:
                    VendaDePedidosParaFestas();
                    break;
                case 10:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Saindo do sistema, Volte Sempre!...");
                    Console.ResetColor();
                    break;
            }
        } while (opcao != 10);
    }
    private void BuscarProduto()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("========================");
        Console.WriteLine("       BUSCAR PRODUTO      ");
        Console.WriteLine("========================");
        Console.ResetColor();
        ListarProdutos();

        Console.Write("Informe o ID do produto que deseja buscar: ");
        if (!int.TryParse(Console.ReadLine(), out int idBusca))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID inválido.");
            Console.ResetColor();
            return;
        }

        Produto produtoEncontrado = Produtos.FirstOrDefault(p => p.Id == idBusca);
        if (produtoEncontrado != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto encontrado:");
            Console.WriteLine($"ID: {produtoEncontrado.Id}");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Categoria: {produtoEncontrado.Categoria}");
            Console.WriteLine($"Quantidade: {produtoEncontrado.Quantidade}");
            Console.WriteLine($"Estoque Mínimo: {produtoEncontrado.EstoqueMinimo}");
            Console.WriteLine($"Preço: R${produtoEncontrado.Preco:F2}");
            Console.WriteLine($"Validade: {produtoEncontrado.Validade:dd/MM/yyyy}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Produto não encontrado.");
            Console.ResetColor();
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    private void SubmenuAtendimento()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n========================");
            Console.WriteLine("       ATENDIMENTO      ");
            Console.WriteLine("========================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n1. Atendimento no Caixa");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Atendimento na Lanchonete");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("3. Consultar Pedido ou Comanda");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         Um Sistema WAD Sistemas");
            Console.ResetColor();
            Console.Write("             Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                Console.ResetColor();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    AtendimentoNoCaixa();
                    break;
                case 2:
                    AtendimentoNaLanchonete();
                    break;
                case 3:
                    ConsultarPedidoOuComanda();
                    break;
                case 4:
                    break;
            }
        } while (opcao != 4);
    }
    private void AtendimentoNoCaixa()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n========================");
        Console.WriteLine("       ATENDIMENTO NO CAIXA      ");
        Console.WriteLine("========================");
        Console.ResetColor();
        ListarProdutos(); // Exibir os produtos disponíveis
        Console.Write("Registrar Venda - Informe o nome do cliente: ");
        string nomeCliente = Console.ReadLine();

        List<Produto> produtosPedido = new List<Produto>();
        bool continuarAdicionando = true;

        while (continuarAdicionando)
        {
            Console.WriteLine("\nDeseja incluir o produto pelo Nome ou pelo ID?");
            Console.WriteLine("1. Nome");
            Console.WriteLine("2. ID");
            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int escolha) || (escolha != 1 && escolha != 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida.");
                Console.ResetColor();
                continue;
            }

            Produto produto = null;

            if (escolha == 1) // Inclusão pelo Nome
            {
                Console.Write("Informe o nome do produto: ");
                string nomeProduto = Console.ReadLine();
                produto = Produtos.FirstOrDefault(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
            }
            else if (escolha == 2) // Inclusão pelo ID
            {
                Console.Write("Informe o ID do produto: ");
                if (int.TryParse(Console.ReadLine(), out int idProduto))
                {
                    produto = Produtos.FirstOrDefault(p => p.Id == idProduto);
                }
                else
   