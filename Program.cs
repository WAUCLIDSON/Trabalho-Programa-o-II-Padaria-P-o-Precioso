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
            Padaria padaria = new Padaria();
            padaria.IniciarSistema();
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
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nID inválido.");
                        Console.ResetColor();
                    }
                }

                if (produto == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProduto não encontrado.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("Informe a quantidade desejada: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade inválida.");
                        Console.ResetColor();
                    }
                    else if (produto.Quantidade < quantidade)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade em estoque insuficiente.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Produto pedidoProduto = new Produto(produto.Id, produto.Nome, produto.Categoria, quantidade, produto.EstoqueMinimo, produto.Preco, produto.Validade);
                        produtosPedido.Add(pedidoProduto);
                        produto.Quantidade -= quantidade; // Atualizar estoque
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nProduto adicionado ao pedido com sucesso!");
                        Console.ResetColor();
                    }
                }

                Console.Write("Deseja adicionar mais produtos ao pedido? (s/n): ");
                continuarAdicionando = Console.ReadLine()?.Trim().ToLower() == "s";
            }

            if (produtosPedido.Count > 0)
            {
                decimal valorTotal = produtosPedido.Sum(p => p.Preco * p.Quantidade); // Calcular o valor total
                Console.WriteLine($"\nValor total do pedido: R${valorTotal:F2}");
                Console.WriteLine("\nEscolha o método de pagamento:");
                Console.WriteLine("1. Dinheiro");
                Console.WriteLine("2. Cartão");
                Console.Write("Opção: ");
                if (!int.TryParse(Console.ReadLine(), out int metodoPagamento) || (metodoPagamento != 1 && metodoPagamento != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMétodo de pagamento inválido. Venda cancelada.");
                    Console.ResetColor();
                    return;
                }

                string formaPagamento = metodoPagamento == 1 ? "Dinheiro" : "Cartão";

                // Registrar venda
                int novoId = Vendas.Count > 0 ? Vendas.Max(v => v.Id) + 1 : 1;
                Venda novaVenda = new Venda(novoId, produtosPedido);
                Vendas.Add(novaVenda);

                // Atualizar caixa
                Caixa.AdicionarRecebimento(valorTotal, formaPagamento);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVenda registrada com sucesso! Valor total: R${valorTotal:F2}");
                Console.WriteLine($"Método de pagamento: {formaPagamento}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNenhum produto foi adicionado ao pedido.");
                Console.ResetColor();
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void AtendimentoNaLanchonete()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================");
            Console.WriteLine("       ATENDIMENTO NA LANCHONETE      ");
            Console.WriteLine("========================");
            Console.ResetColor();
            ListarProdutos();
            Console.Write("Informe o nome do cliente para registrar a comanda: ");
            string nomeCliente = Console.ReadLine();

            List<Produto> produtosComanda = new List<Produto>();
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

                if (escolha == 1)
                {
                    Console.Write("Informe o nome do produto: ");
                    string nomeProduto = Console.ReadLine();
                    produto = Produtos.FirstOrDefault(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
                }
                else if (escolha == 2)
                {
                    Console.Write("Informe o ID do produto: ");
                    if (int.TryParse(Console.ReadLine(), out int idProduto))
                    {
                        produto = Produtos.FirstOrDefault(p => p.Id == idProduto);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nID inválido.");
                        Console.ResetColor();
                    }
                }

                if (produto == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProduto não encontrado.");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("Informe a quantidade desejada: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade inválida.");
                        Console.ResetColor();
                    }
                    else if (produto.Quantidade < quantidade)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nQuantidade em estoque insuficiente.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Produto comandaProduto = new Produto(produto.Id, produto.Nome, produto.Categoria, quantidade, produto.EstoqueMinimo, produto.Preco, produto.Validade);
                        produtosComanda.Add(comandaProduto);
                        produto.Quantidade -= quantidade;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nProduto adicionado à comanda com sucesso!");
                        Console.ResetColor();
                    }
                }

                Console.Write("Deseja adicionar mais produtos à comanda? (s/n): ");
                continuarAdicionando = Console.ReadLine()?.Trim().ToLower() == "s";
            }

            if (produtosComanda.Count > 0)
            {
                int novaId = Comandas.Count > 0 ? Comandas.Keys.Select(int.Parse).Max() + 1 : 1;
                Comandas.Add(novaId.ToString(), new List<Pedido> { new Pedido(novaId, nomeCliente, produtosComanda) });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nComanda registrada com sucesso!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNenhum produto foi adicionado à comanda.");
                Console.ResetColor();
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void ConsultarPedidoOuComanda()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n========================");
            Console.WriteLine("       CONSULTAR PEDIDO OU COMANDA      ");
            Console.WriteLine("========================");
            Console.ResetColor();
            Console.WriteLine("\nPedidos:");
            foreach (var venda in Vendas.OrderBy(v => v.Id))
            {
                Console.WriteLine($"ID: {venda.Id}, Data: {venda.Data}, Valor: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade)}");
            }

            Console.WriteLine("\nComandas:");
            foreach (var comanda in Comandas.OrderBy(c => int.Parse(c.Key)))
            {
                Console.WriteLine($"ID: {comanda.Key}, Cliente: {comanda.Value.First().NomeCliente}, Valor: R${comanda.Value.First().Produtos.Sum(p => p.Preco * p.Quantidade)}");
            }

            Console.WriteLine("\nDeseja consultar um pedido ou comanda específico por ID ou Nome?");
            Console.WriteLine("1. Consultar por ID");
            Console.WriteLine("2. Consultar por Nome");
            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int consultaOpcao) || consultaOpcao < 1 || consultaOpcao > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida.");
                Console.ResetColor();
                return;
            }

            if (consultaOpcao == 1)
            {
                Console.Write("Informe o ID do pedido ou comanda: ");
                string idConsulta = Console.ReadLine();
                if (Vendas.Any(v => v.Id.ToString() == idConsulta))
                {
                    var venda = Vendas.First(v => v.Id.ToString() == idConsulta);
                    MostrarDetalhesVenda(venda);
                }
                else if (Comandas.ContainsKey(idConsulta))
                {
                    var comanda = Comandas[idConsulta].First();
                    MostrarDetalhesComanda(comanda);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nID não encontrado.");
                    Console.ResetColor();
                }
            }
            else if (consultaOpcao == 2)
            {
                Console.Write("Informe o nome do cliente: ");
                string nomeConsulta = Console.ReadLine();
                if (Comandas.Any(c => c.Value.First().NomeCliente.Equals(nomeConsulta, StringComparison.OrdinalIgnoreCase)))
                {
                    var comanda = Comandas.First(c => c.Value.First().NomeCliente.Equals(nomeConsulta, StringComparison.OrdinalIgnoreCase)).Value.First();
                    MostrarDetalhesComanda(comanda);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNome não encontrado.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void MostrarDetalhesVenda(Venda venda)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine($"DETALHES DO PEDIDO ID: {venda.Id}");
            Console.WriteLine("========================");
            Console.ResetColor();
            foreach (var produto in venda.Produtos)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço Unitário: R${produto.Preco}, Total: R${produto.Preco * produto.Quantidade}");
            }
            Console.WriteLine($"\nValor Total do Pedido: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade)}");
        }

        private void MostrarDetalhesComanda(Pedido comanda)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine($"DETALHES DA COMANDA ID: {comanda.Id}");
            Console.WriteLine("========================");
            Console.ResetColor();
            foreach (var produto in comanda.Produtos)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço Unitário: R${produto.Preco}, Total: R${produto.Preco * produto.Quantidade}");
            }
            Console.WriteLine($"\nValor Total da Comanda: R${comanda.Produtos.Sum(p => p.Preco * p.Quantidade)}");
        }
        private void GestaoDeCaixa()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n========================");
                Console.WriteLine("     GESTÃO DE CAIXA     ");
                Console.WriteLine("========================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=================================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Controle de Saída");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. Fechamento por Comanda (Com Recebimento)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("3. Relatório de Vendas por Período");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("4. Valor Total dos Produtos em Estoque (Detalhado)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("5. Relatório Detalhado do Caixa");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("6. Extrato Geral de Comandas e Pedidos");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("7. Verificar Saldo e Alertas");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("8. Salvar Relatórios em Arquivo");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("9. Voltar ao Menu Principal");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=================================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("         Um Sistema WAD Sistemas");
                Console.ResetColor();
                Console.WriteLine("========================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida. Tente novamente.");
                    Console.ResetColor();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        ControleDeSaida();
                        break;
                    case 2:
                        FechamentoPorComandaComRecebimento();
                        break;
                    case 3:
                        RelatorioVendasPorPeriodo();
                        break;
                    case 4:
                        ValorTotalProdutosEstoqueDetalhado();
                        break;
                    case 5:
                        ExtratoDetalhadoCaixa();
                        break;
                    case 6:
                        ExtratoGeralDeComandasEPedidos();
                        break;
                    case 7:
                        VerificarSaldoComAlerta();
                        break;
                    case 8:
                        SalvarRelatorios();
                        break;
                    case 9:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                }
            } while (opcao != 8);
        }
        private void GerarRelatorioCaixa()
        {
            string caminhoRelatorio = "relatorio_fluxo_caixa.txt";
            using (StreamWriter writer = new StreamWriter(caminhoRelatorio))
            {
                writer.WriteLine("RELATÓRIO DETALHADO DO CAIXA");
                writer.WriteLine("=============================");
                writer.WriteLine($"Saldo Atual: R${Caixa.Saldo:F2}");
                writer.WriteLine("\nEntradas:");
                foreach (var recebimento in Caixa.Recebimentos)
                {
                    writer.WriteLine($"Valor: R${recebimento.Valor:F2}, Forma de Pagamento: {recebimento.FormaPagamento}, Data: {recebimento.Data}");
                }
                writer.WriteLine("=============================");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRelatório de caixa salvo em: {caminhoRelatorio}");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void GerarRelatorioVendasPorPeriodo()
        {
            Console.Write("Informe a data inicial (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInicial))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData inválida.");
                Console.ResetColor();
                return;
            }

            Console.Write("Informe a data final (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataFinal))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData inválida.");
                Console.ResetColor();
                return;
            }

            var vendasFiltradas = Vendas.Where(v => v.Data.Date >= dataInicial.Date && v.Data.Date <= dataFinal.Date);
            string caminhoRelatorio = "relatorio_vendas_periodo.txt";
            using (StreamWriter writer = new StreamWriter(caminhoRelatorio))
            {
                writer.WriteLine("RELATÓRIO DE VENDAS POR PERÍODO");
                writer.WriteLine($"Período: {dataInicial:dd/MM/yyyy} - {dataFinal:dd/MM/yyyy}");
                writer.WriteLine("=============================");
                if (!vendasFiltradas.Any())
                {
                    writer.WriteLine("Nenhuma venda registrada no período especificado.");
                }
                else
                {
                    foreach (var venda in vendasFiltradas)
                    {
                        writer.WriteLine($"ID: {venda.Id}, Data: {venda.Data}, Valor: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade):F2}");
                    }
                }
                writer.WriteLine("=============================");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRelatório de vendas salvo em: {caminhoRelatorio}");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        private void SalvarRelatorios()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine("     SALVAR RELATÓRIOS     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            string caminhoArquivo = "relatorios_gestao_caixa.txt";

            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                writer.WriteLine("=== Relatório de Vendas por Período ===");
                foreach (var venda in Vendas)
                {
                    writer.WriteLine($"ID: {venda.Id}, Data: {venda.Data}, Valor Total: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade):F2}");
                }

                writer.WriteLine("\n=== Relatório Detalhado do Caixa ===");
                writer.WriteLine($"Saldo Atual: R${Caixa.Saldo:F2}");
                foreach (var recebimento in Caixa.Recebimentos)
                {
                    writer.WriteLine($"Valor: R${recebimento.Valor:F2}, Forma de Pagamento: {recebimento.FormaPagamento}, Data: {recebimento.Data}");
                }

                writer.WriteLine("\n=== Valor Total dos Produtos em Estoque ===");
                var valorPorCategoria = Produtos.GroupBy(p => p.Categoria)
                    .Select(g => new { Categoria = g.Key, Valor = g.Sum(p => p.Quantidade * p.Preco) });
                foreach (var categoria in valorPorCategoria)
                {
                    writer.WriteLine($"Categoria: {categoria.Categoria}, Valor Total: R${categoria.Valor:F2}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRelatórios salvos com sucesso em: {caminhoArquivo}");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void GerarRelatorioEstoque()
        {
            string caminhoRelatorio = "relatorio_estoque_detalhado.txt";
            using (StreamWriter writer = new StreamWriter(caminhoRelatorio))
            {
                writer.WriteLine("RELATÓRIO DETALHADO DE ESTOQUE");
                writer.WriteLine("=============================");
                var valorPorCategoria = Produtos.GroupBy(p => p.Categoria)
                    .Select(g => new { Categoria = g.Key, Valor = g.Sum(p => p.Quantidade * p.Preco) });

                foreach (var categoria in valorPorCategoria)
                {
                    writer.WriteLine($"Categoria: {categoria.Categoria}, Valor Total: R${categoria.Valor:F2}");
                }

                decimal valorTotalEstoque = Produtos.Sum(p => p.Quantidade * p.Preco);
                writer.WriteLine($"\nValor total em estoque: R${valorTotalEstoque:F2}");
                writer.WriteLine("=============================");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRelatório de estoque salvo em: {caminhoRelatorio}");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private void ControleDeSaida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n========================");
            Console.WriteLine("     CONTROLE DE SAÍDA     ");
            Console.WriteLine("========================");
            Console.ResetColor();
            Console.Write("Informe o valor da saída: R$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valorSaida) || valorSaida <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nValor inválido.");
                Console.ResetColor();
                return;
            }

            Caixa.RemoverValor(valorSaida);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSaída registrada com sucesso!");
            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void FechamentoPorComandaComRecebimento()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n========================");
            Console.WriteLine("     FECHAMENTO POR COMANDA     ");
            Console.WriteLine("========================");
            Console.ResetColor();

            if (!Comandas.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNenhuma comanda registrada.");
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nComandas Disponíveis:");
            foreach (var comanda in Comandas)
            {
                var pedidos = comanda.Value;
                decimal valorTotal = pedidos.Sum(p => p.Produtos.Sum(prod => prod.Preco * prod.Quantidade));
                Console.WriteLine($"ID: {comanda.Key} | Cliente: {pedidos.First().NomeCliente} | Valor Total: R${valorTotal:F2}");
            }

            Console.Write("\nInforme o ID da comanda para fechar: ");
            string idComanda = Console.ReadLine();

            if (Comandas.ContainsKey(idComanda))
            {
                var pedidos = Comandas[idComanda];
                decimal valorTotal = pedidos.Sum(p => p.Produtos.Sum(prod => prod.Preco * prod.Quantidade));

                Console.WriteLine($"\nValor total da comanda '{idComanda}': R${valorTotal:F2}");
                Console.WriteLine("\nEscolha o método de pagamento:");
                Console.WriteLine("1. Dinheiro");
                Console.WriteLine("2. Cartão");
                Console.Write("Opção: ");
                if (!int.TryParse(Console.ReadLine(), out int metodoPagamento) || (metodoPagamento != 1 && metodoPagamento != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMétodo de pagamento inválido.");
                    Console.ResetColor();
                    return;
                }

                // Registrar recebimento no caixa
                string formaPagamento = metodoPagamento == 1 ? "Dinheiro" : "Cartão";
                Caixa.AdicionarRecebimento(valorTotal, formaPagamento);

                // Remover comanda após fechamento
                Comandas.Remove(idComanda);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nFechamento da comanda '{idComanda}' realizado com sucesso! Valor recebido: R${valorTotal:F2}");
                Console.WriteLine($"Método de pagamento: {formaPagamento}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nComanda não encontrada.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void RelatorioVendasPorPeriodo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine("     RELATÓRIO DE VENDAS POR PERÍODO     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            Console.Write("Informe a data inicial (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInicial))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData inválida.");
                Console.ResetColor();
                return;
            }

            Console.Write("Informe a data final (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataFinal))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData inválida.");
                Console.ResetColor();
                return;
            }

            var vendasFiltradas = Vendas.Where(v => v.Data.Date >= dataInicial.Date && v.Data.Date <= dataFinal.Date);
            if (!vendasFiltradas.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNenhuma venda registrada no período especificado.");
                Console.ResetColor();
            }
            else
            {
                foreach (var venda in vendasFiltradas)
                {
                    Console.WriteLine($"ID: {venda.Id}, Data: {venda.Data}, Valor: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade):F2}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void ValorTotalProdutosEstoqueDetalhado()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n========================");
            Console.WriteLine("     VALOR TOTAL DOS PRODUTOS EM ESTOQUE     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            var valorPorCategoria = Produtos.GroupBy(p => p.Categoria)
                .Select(g => new { Categoria = g.Key, Valor = g.Sum(p => p.Quantidade * p.Preco) });

            foreach (var categoria in valorPorCategoria)
            {
                Console.WriteLine($"Categoria: {categoria.Categoria}, Valor Total: R${categoria.Valor:F2}");
            }

            decimal valorTotalEstoque = Produtos.Sum(p => p.Quantidade * p.Preco);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nValor total em estoque: R${valorTotalEstoque:F2}");
            Console.ResetColor();

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void ExtratoDetalhadoCaixa()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================");
            Console.WriteLine("     RELATÓRIO DETALHADO DO CAIXA     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            Console.WriteLine($"Saldo Atual: R${Caixa.Saldo:F2}");
            Console.WriteLine("\nEntradas:");

            foreach (var recebimento in Caixa.Recebimentos)
            {
                Console.WriteLine($"Valor: R${recebimento.Valor:F2}, Forma de Pagamento: {recebimento.FormaPagamento}, Data: {recebimento.Data}");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void VerificarSaldoComAlerta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n========================");
            Console.WriteLine("     SALDO ATUAL E ALERTA DE LIMITE     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            Console.WriteLine($"Saldo Atual: R${Caixa.Saldo:F2}");
            if (Caixa.Saldo < 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nALERTA: O saldo está abaixo do limite de segurança!");
                Console.ResetColor();
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void ExtratoGeralDeComandasEPedidos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine("     EXTRATO DE COMANDAS E PEDIDOS     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            Console.WriteLine("Comandas:");
            foreach (var comanda in Comandas)
            {
                Console.WriteLine($"ID: {comanda.Key}, Cliente: {comanda.Value.First().NomeCliente}, Valor Total: R${comanda.Value.First().Produtos.Sum(p => p.Preco * p.Quantidade):F2}");
            }

            Console.WriteLine("\nPedidos:");
            foreach (var venda in Vendas)
            {
                Console.WriteLine($"ID: {venda.Id}, Data: {venda.Data}, Valor Total: R${venda.Produtos.Sum(p => p.Preco * p.Quantidade):F2}");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void SubmenuProdutos()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n========================");
                Console.WriteLine("       NOSSOS PRODUTOS      ");
                Console.WriteLine("========================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=================================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n1. Listar Produtos");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. Adicionar Um Novo Produto");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("3. Excluir Um Produto");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("4. Voltar ao Menu Principal");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("=================================================");
                Console.ResetColor();
                Console.Write("Escolha uma opção: ");
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
                        ListarProdutos();
                        break;
                    case 2:
                        AdicionarNovoProduto();
                        break;
                    case 3:
                        ExcluirProduto();
                        break;
                    case 4:
                        break;
                }
            } while (opcao != 4);
        }

        private void ListarProdutos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine("       LISTA DE PRODUTOS       ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            if (!Produtos.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum produto cadastrado no sistema.");
                Console.ResetColor();
            }
            else
            {
                foreach (var produto in Produtos)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Categoria: {produto.Categoria} | Quantidade: {produto.Quantidade}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Preço: R${produto.Preco:F2} | Validade: {produto.Validade:dd/MM/yyyy}");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------");
                }
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }


        private void AdicionarNovoProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n========================");
            Console.WriteLine("  ADICIONAR UM NOVO PRODUTO  ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            ListarProdutos();
            Console.Write("\nInforme o nome do produto: ");
            string nome = Console.ReadLine();
            if (!int.TryParse(Console.ReadLine(), out int id))


                if (Produtos.Any(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProduto já existe. Obrigado!");
                    Console.ResetColor();
                    return;
                }

            // Mostrar categorias disponíveis
            Console.WriteLine("\nCategorias disponíveis:");
            var categorias = Produtos.Select(p => p.Categoria).Distinct().ToList();
            for (int i = 0; i < categorias.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i + 1}. {categorias[i]}");
                Console.ResetColor();
            }
            Console.Write("Escolha o ID da categoria: ");
            if (!int.TryParse(Console.ReadLine(), out int categoriaId) || categoriaId < 1 || categoriaId > categorias.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCategoria inválida.");
                Console.ResetColor();
                return;
            }
            string categoria = categorias[categoriaId - 1];

            Console.Write("Informe a quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nQuantidade inválida.");
                Console.ResetColor();
                return;
            }
            Console.Write("Informe o estoque mínimo: ");
            if (!int.TryParse(Console.ReadLine(), out int estoqueMinimo) || estoqueMinimo < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEstoque mínimo inválido.");
                Console.ResetColor();
                return;
            }
            Console.Write("Informe o preço do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco) || preco < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPreço inválido.");
                Console.ResetColor();
                return;
            }
            Console.Write("Informe a validade (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime validade))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nData de validade inválida.");
                Console.ResetColor();
                return;
            }

            int novoId = Produtos.Count > 0 ? Produtos.Max(p => p.Id) + 1 : 1;
            Produtos.Add(new Produto(novoId, nome, categoria, quantidade, estoqueMinimo, preco, validade));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProduto adicionado com sucesso!");
            Console.ResetColor();
            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void ExcluirProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n========================");
            Console.WriteLine("  EXCLUIR UM PRODUTO  ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            ListarProdutos();
            Console.Write("Informe o ID do produto que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nID inválido.");
                Console.ResetColor();
                return;
            }
            Produto produto = Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduto não encontrado.");
                Console.ResetColor();
                return;
            }

            Console.Write($"Tem certeza que deseja excluir o produto '{produto.Nome}'? (s/n): ");
            string confirmacao = Console.ReadLine();

            if (confirmacao.Equals("s", StringComparison.OrdinalIgnoreCase))
            {
                Produtos.Remove(produto);
                ReorganizarIds();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nProduto excluído com sucesso!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nOperação cancelada.");
                Console.ResetColor();
            }
        }

        private void ReorganizarIds()
        {
            for (int i = 0; i < Produtos.Count; i++)
            {
                Produtos[i].Id = i + 1;
            }
        }
        private void ControleDeEstoque()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n========================");
            Console.WriteLine("     CONTROLE DE ESTOQUE     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            var produtosEstoqueMinimo = Produtos.Where(p => p.Quantidade <= p.EstoqueMinimo);
            var produtosVencidos = Produtos.Where(p => p.Validade < DateTime.Now);
            var produtosAVencer = Produtos.Where(p => (p.Validade - DateTime.Now).Days <= 7 && p.Validade >= DateTime.Now);
            var produtosEstoqueZero = Produtos.Where(p => p.Quantidade == 0);

            // Produtos em Estoque Mínimo
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Produtos em Estoque Mínimo:");
            foreach (var produto in produtosEstoqueMinimo)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(produto.ToString(true));
            }

            // Produtos Vencidos
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProdutos Vencidos:");
            foreach (var produto in produtosVencidos)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(produto.ToString(true));
            }

            // Produtos À Vencer
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nProdutos À Vencer (próximos 7 dias):");
            foreach (var produto in produtosAVencer)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(produto.ToString(true));
            }

            // Produtos em Ruptura de Estoque (Estoque Zero)
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nProdutos em Ruptura (Estoque Zero):");
            foreach (var produto in produtosEstoqueZero)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(produto.ToString(true));
            }

            Console.ResetColor();
            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nUm Sistema WAD Sistemas");
            Console.ResetColor();
        }

        private void ReposicaoDeProdutos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n========================");
            Console.WriteLine("     REPOSIÇÃO DE PRODUTOS    ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            var produtosNecessitamReposicao = Produtos.Where(p => p.Quantidade <= p.EstoqueMinimo);

            Console.WriteLine("Produtos que necessitam de reposição:");
            foreach (var produto in produtosNecessitamReposicao)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(produto.ToString(true));
                Console.ResetColor();
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void EntradaDeProdutos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================");
            Console.WriteLine("  ENTRADA DE PRODUTOS DE FORNECEDORES  ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            // Listar todos os produtos cadastrados
            Console.WriteLine("Produtos Cadastrados:");
            ListarProdutos();

            Console.Write("\nInforme o ID do produto que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int idProduto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nID inválido. Tente novamente.");
                Console.ResetColor();
                return;
            }

            // Buscar produto pelo ID
            Produto produto = Produtos.FirstOrDefault(p => p.Id == idProduto);
            if (produto == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProduto não encontrado. Verifique o ID e tente novamente.");
                Console.ResetColor();
                return;
            }

            // Solicitar a quantidade a ser adicionada
            Console.Write($"Informe a quantidade recebida para o produto '{produto.Nome}': ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nQuantidade inválida. Deve ser maior que zero.");
                Console.ResetColor();
                return;
            }

            // Atualizar a quantidade no estoque
            produto.Quantidade += quantidade;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEstoque atualizado com sucesso! O produto '{produto.Nome}' agora tem {produto.Quantidade} unidades.");
            Console.ResetColor();

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void VendaDePedidosParaFestas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n========================");
            Console.WriteLine("  VENDA DE PEDIDOS PARA FESTAS  ");
            Console.WriteLine("========================\n");
            Console.ResetColor();

            Console.Write("Informe o nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            List<Produto> produtosPedido = new List<Produto>();
            bool continuarAdicionando = true;

            while (continuarAdicionando)
            {
                // Exibir produtos cadastrados
                Console.WriteLine("\nProdutos Disponíveis:");
                ListarProdutos();

                Console.Write("\nInforme o ID do produto que deseja incluir no pedido: ");
                if (!int.TryParse(Console.ReadLine(), out int idProduto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nID inválido. Tente novamente.");
                    Console.ResetColor();
                    continue;
                }

                // Buscar o produto pelo ID
                Produto produto = Produtos.FirstOrDefault(p => p.Id == idProduto);
                if (produto == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nProduto não encontrado. Verifique o ID e tente novamente.");
                    Console.ResetColor();
                    continue;
                }

                Console.Write($"Informe a quantidade desejada para o produto '{produto.Nome}': ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nQuantidade inválida. Deve ser maior que zero.");
                    Console.ResetColor();
                    continue;
                }

                if (produto.Quantidade < quantidade)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nQuantidade insuficiente em estoque.");
                    Console.ResetColor();
                    continue;
                }

                // Adicionar produto ao pedido e atualizar estoque
                Produto pedidoProduto = new Produto(produto.Id, produto.Nome, produto.Categoria, quantidade, produto.EstoqueMinimo, produto.Preco, produto.Validade);
                produtosPedido.Add(pedidoProduto);
                produto.Quantidade -= quantidade;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProduto '{produto.Nome}' adicionado ao pedido com sucesso!");
                Console.ResetColor();

                Console.Write("Deseja adicionar mais produtos ao pedido? (s/n): ");
                continuarAdicionando = Console.ReadLine()?.Trim().ToLower() == "s";
            }

            if (produtosPedido.Count > 0)
            {
                // Registrar o pedido como uma nova venda
                int novoId = Vendas.Count > 0 ? Vendas.Max(v => v.Id) + 1 : 1;
                Venda novaVenda = new Venda(novoId, produtosPedido);
                Vendas.Add(novaVenda);

                // Calcular o valor total da venda
                decimal valorTotal = produtosPedido.Sum(p => p.Preco * p.Quantidade);

                // Solicitar o método de pagamento
                Console.WriteLine("\nEscolha o método de pagamento:");
                Console.WriteLine("1. Dinheiro");
                Console.WriteLine("2. Cartão");
                Console.Write("Opção: ");
                if (!int.TryParse(Console.ReadLine(), out int metodoPagamento) || (metodoPagamento != 1 && metodoPagamento != 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMétodo de pagamento inválido. Operação cancelada.");
                    Console.ResetColor();
                    return;
                }

                // Atualizar o caixa com o valor total da venda e o método de pagamento
                string formaPagamento = metodoPagamento == 1 ? "Dinheiro" : "Cartão";
                Caixa.AdicionarRecebimento(valorTotal, formaPagamento);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nVenda registrada com sucesso! Valor total: R${valorTotal:F2}");
                Console.WriteLine($"Método de pagamento: {formaPagamento}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNenhum produto foi adicionado ao pedido.");
                Console.ResetColor();
            }

            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void SubmenuInventario()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n========================");
                Console.WriteLine("     GESTÃO DE INVENTÁRIO     ");
                Console.WriteLine("========================\n");
                Console.ResetColor();
                Console.WriteLine("1. Abrir Contagem");
                Console.WriteLine("2. Digitar Contagem");
                Console.WriteLine("3. Resultado da Contagem");
                Console.WriteLine("4. Voltar ao Menu Principal");
                Console.WriteLine("========================");
                Console.Write("Escolha uma opção: ");
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
                        AbrirContagem();
                        break;
                    case 2:
                        DigitarContagem();
                        break;
                    case 3:
                        ResultadoContagem();
                        break;
                    case 4:
                        break;
                }
            } while (opcao != 4);
        }

        private void AbrirContagem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n========================");
            Console.WriteLine("     ABRIR CONTAGEM DE INVENTÁRIO     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            string caminhoArquivo = "contagem_inventario.txt";

            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var produto in Produtos)
                {
                    writer.WriteLine(produto.Nome);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nArquivo de contagem gerado: {caminhoArquivo}");
            Console.ResetColor();
            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void DigitarContagem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n========================");
            Console.WriteLine("     DIGITAR CONTAGEM DE INVENTÁRIO     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            foreach (var produto in Produtos)
            {
                Console.Write($"Digite a quantidade contada para o produto '{produto.Nome}': ");
                if (!int.TryParse(Console.ReadLine(), out int quantidadeContada) || quantidadeContada < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nQuantidade inválida.");
                    Console.ResetColor();
                    return;
                }
                ContagemInventario[produto.Id] = quantidadeContada;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nContagem registrada com sucesso!");
            Console.ResetColor();
            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private void ResultadoContagem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n========================");
            Console.WriteLine("     RESULTADO DA CONTAGEM DE INVENTÁRIO     ");
            Console.WriteLine("========================\n");
            Console.ResetColor();
            string caminhoArquivoResultado = "resultado_contagem_inventario.txt";

            using (StreamWriter writer = new StreamWriter(caminhoArquivoResultado))
            {
                foreach (var produto in Produtos)
                {
                    if (ContagemInventario.ContainsKey(produto.Id))
                    {
                        int quantidadeContada = ContagemInventario[produto.Id];
                        if (quantidadeContada != produto.Quantidade)
                        {
                            writer.WriteLine($"Produto: {produto.Nome}, Quantidade Esperada: {produto.Quantidade}, Quantidade Contada: {quantidadeContada}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Divergência encontrada no produto '{produto.Nome}': Esperado = {produto.Quantidade}, Contado = {quantidadeContada}");
                            Console.ResetColor();
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nArquivo de resultado de contagem gerado: {caminhoArquivoResultado}");
            Console.ResetColor();
            Console.WriteLine("\n========================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }


        private void BuscarProdutoPorID()
        {
            Console.Clear();
            Console.WriteLine("==== BUSCAR PRODUTO POR ID ====");
            ListarProdutos();

            Console.Write("Digite o ID do produto que deseja buscar: ");
            if (!int.TryParse(Console.ReadLine(), out int idBusca))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            var produtoEncontrado = Produtos.FirstOrDefault(p => p.Id == idBusca);
            if (produtoEncontrado != null)
            {
                Console.WriteLine("==== PRODUTO ENCONTRADO ====");
                Console.WriteLine($"ID: {produtoEncontrado.Id}");
                Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
                Console.WriteLine($"Categoria: {produtoEncontrado.Categoria}");
                Console.WriteLine($"Quantidade: {produtoEncontrado.Quantidade}");
                Console.WriteLine($"Preço: R${produtoEncontrado.Preco:F2}");
                Console.WriteLine($"Validade: {produtoEncontrado.Validade:dd/MM/yyyy}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
            Console.WriteLine("=============================");
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
        private void CarregarProdutos()
        {
            Produtos.Add(new Produto(1, "Pão Francês", "Pães Artesanais", 50, 100, 1.50m, DateTime.Now.AddDays(1)));
            Produtos.Add(new Produto(2, "Pão Integral", "Pães Artesanais", 0, 5, 2.00m, DateTime.Now.AddDays(2)));
            Produtos.Add(new Produto(3, "Pão de Leite", "Pães Artesanais", 30, 50, 1.80m, DateTime.Now.AddDays(3)));
            Produtos.Add(new Produto(4, "Pão Italiano", "Pães Artesanais", 15, 5, 3.50m, DateTime.Now.AddDays(4)));
            Produtos.Add(new Produto(5, "Pão Multigrãos", "Pães Artesanais", 25, 10, 2.80m, DateTime.Now.AddDays(5)));
            Produtos.Add(new Produto(6, "Focaccia de Alecrim", "Pães Artesanais", 10, 20, 4.50m, DateTime.Now.AddDays(6)));
            Produtos.Add(new Produto(7, "Bolo de Cenoura com Cobertura de Chocolate", "Bolos e Tortas", 10, 3, 15.00m, DateTime.Now.AddDays(-3)));
            Produtos.Add(new Produto(8, "Bolo de Laranja", "Bolos e Tortas", 0, 3, 12.00m, DateTime.Now.AddDays(-3)));
            Produtos.Add(new Produto(9, "Bolo de Milho", "Bolos e Tortas", 5, 9, 10.00m, DateTime.Now.AddDays(4)));
            Produtos.Add(new Produto(10, "Torta de Limão", "Bolos e Tortas", 7, 3, 18.00m, DateTime.Now.AddDays(-5)));
            Produtos.Add(new Produto(11, "Torta de Maçã", "Bolos e Tortas", 0, 2, 20.00m, DateTime.Now.AddDays(6)));
            Produtos.Add(new Produto(12, "Cheesecake de Frutas Vermelhas", "Bolos e Tortas", 6, 2, 25.00m, DateTime.Now.AddDays(7)));
            Produtos.Add(new Produto(13, "Coxinha de Frango", "Salgados", 30, 10, 5.00m, DateTime.Now.AddDays(1)));
            Produtos.Add(new Produto(14, "Empada de Palmito", "Salgados", 20, 5, 6.50m, DateTime.Now.AddDays(2)));
            Produtos.Add(new Produto(15, "Quiche de Alho-Poró", "Salgados", 12, 3, 8.00m, DateTime.Now.AddDays(3)));
            Produtos.Add(new Produto(16, "Pastel de Forno de Carne ou Queijo", "Salgados", 15, 5, 7.50m, DateTime.Now.AddDays(-4)));
            Produtos.Add(new Produto(17, "Croissant Recheado (Presunto e Queijo, Chocolate)", "Salgados", 18, 6, 9.00m, DateTime.Now.AddDays(5)));
            Produtos.Add(new Produto(18, "Brigadeiro", "Doces", 50, 20, 1.50m, DateTime.Now.AddDays(10)));
            Produtos.Add(new Produto(19, "Beijinho", "Doces", 0, 15, 1.50m, DateTime.Now.AddDays(10)));
            Produtos.Add(new Produto(20, "Trufa de Chocolate", "Doces", 30, 10, 3.00m, DateTime.Now.AddDays(15)));
            Produtos.Add(new Produto(21, "Fatia de Pudim de Leite Condensado", "Doces", 20, 5, 4.00m, DateTime.Now.AddDays(5)));
            Produtos.Add(new Produto(22, "Doce de Abóbora com Coco", "Doces", 25, 10, 2.50m, DateTime.Now.AddDays(7)));
            Produtos.Add(new Produto(23, "Café Expresso", "Bebidas", 50, 100, 3.50m, DateTime.Now.AddDays(20)));
            Produtos.Add(new Produto(24, "Cappuccino", "Bebidas", 30, 10, 4.00m, DateTime.Now.AddDays(30)));
            Produtos.Add(new Produto(25, "Suco Natural (Laranja, Morango, Limão)", "Bebidas", 20, 5, 5.00m, DateTime.Now.AddDays(3)));
            Produtos.Add(new Produto(26, "Chocolate Quente", "Bebidas", 15, 5, 4.50m, DateTime.Now.AddDays(20)));
            Produtos.Add(new Produto(27, "Refrigerante", "Bebidas", 40, 10, 3.00m, DateTime.Now.AddDays(60)));
            Produtos.Add(new Produto(28, "Misto Quente", "Sanduíches e Lanches", 25, 8, 6.00m, DateTime.Now.AddDays(2)));
            Produtos.Add(new Produto(29, "Sanduíche Natural (Frango, Atum ou Vegetariano)", "Sanduíches e Lanches", 20, 5, 7.50m, DateTime.Now.AddDays(3)));
            Produtos.Add(new Produto(30, "Hambúrguer Artesanal", "Sanduíches e Lanches", 12, 5, 10.00m, DateTime.Now.AddDays(4)));
            Produtos.Add(new Produto(31, "Pão na Chapa com Requeijão", "Sanduíches e Lanches", 15, 5, 4.00m, DateTime.Now.AddDays(2)));
            Produtos.Add(new Produto(32, "Baguete de Alho", "Produtos Especiais", 10, 3, 5.00m, DateTime.Now.AddDays(7)));
            Produtos.Add(new Produto(33, "Pão Vegano", "Produtos Especiais", 8, 3, 6.00m, DateTime.Now.AddDays(8)));
            Produtos.Add(new Produto(34, "Doces Diet (Pudim, Torta Diet)", "Produtos Especiais", 5, 2, 8.00m, DateTime.Now.AddDays(7)));
            Produtos.Add(new Produto(35, "Pães sem Glúten", "Produtos Especiais", 10, 5, 7.50m, DateTime.Now.AddDays(6)));
            Produtos.Add(new Produto(36, "Bolos de Aniversário", "Encomendas Personalizadas", 3, 1, 50.00m, DateTime.Now.AddDays(15)));
            Produtos.Add(new Produto(37, "Kits para Café da Manhã", "Encomendas Personalizadas", 5, 2, 45.00m, DateTime.Now.AddDays(10)));
            Produtos.Add(new Produto(38, "Cestas de Pães e Doces", "Encomendas Personalizadas", 6, 2, 40.00m, DateTime.Now.AddDays(10)));
        }
    }
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
        public decimal Preco { get; set; }
        public DateTime Validade { get; set; }

        public Produto(int id, string nome, string categoria, int quantidade, int estoqueMinimo, decimal preco, DateTime validade)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Quantidade = quantidade;
            EstoqueMinimo = estoqueMinimo;
            Preco = preco;
            Validade = validade;

        }

        public string ToString(bool incluirCategoria)
        {
            if (incluirCategoria)
            {
                return $"ID: {Id}, Produto: {Nome}, Categoria: {Categoria}, Quantidade: {Quantidade}, Estoque Mínimo: {EstoqueMinimo}, Preço: R${Preco}, Validade: {Validade.ToShortDateString()}";
            }
            else
            {
                return $"ID: {Id}, Produto: {Nome}, Quantidade: {Quantidade}, Estoque Mínimo: {EstoqueMinimo}, Preço: R${Preco}, Validade: {Validade.ToShortDateString()}";
            }
        }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<Produto> Produtos { get; set; }

        public Pedido(int id, string nomeCliente, List<Produto> produtos)
        {
            Id = id;
            NomeCliente = nomeCliente;
            Produtos = produtos;
        }
    }
    public class Caixa
    {
        public decimal Saldo { get; private set; }
        public List<(decimal Valor, string FormaPagamento, DateTime Data)> Recebimentos { get; private set; }

        public Caixa()
        {
            Saldo = 0;
            Recebimentos = new List<(decimal, string, DateTime)>();
        }

        public void AdicionarRecebimento(decimal valor, string formaPagamento)
        {
            Saldo += valor;
            Recebimentos.Add((valor, formaPagamento, DateTime.Now));
        }

        public void RemoverValor(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
        }
    }

    public class Venda
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public DateTime Data { get; set; }

        public Venda(int id, List<Produto> produtos)
        {
            Id = id;
            Produtos = produtos;
            Data = DateTime.Now;
        }
    }
}
