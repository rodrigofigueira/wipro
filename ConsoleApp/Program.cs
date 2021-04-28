using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            GetItem().Wait();
            Console.ReadLine();
        }
        static async Task GetItem()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44336/");
                HttpResponseMessage response = await client.GetAsync("api/fila/getitemfila");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Fila vazia, aguardar novo ciclo de verificação...");
                }
                else
                {
                    DateTime inicioProcesso = DateTime.Now;
                    Console.WriteLine("---------------------------------------------------------------------------");
                    Console.WriteLine($"Inicio do processamento: {inicioProcesso.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Moeda moeda = JsonConvert.DeserializeObject<Moeda>(await response.Content.ReadAsStringAsync());
                    Console.WriteLine($"Processando moeda: {moeda.moeda}");
                    List<DadosMoeda> moedas = SelecionarMoedasComCodigoCotacao(moeda);
                    List<DadosCotacao> cotacoes = ListarCotacoes();                    
                    ValorizarMoedas(moedas, cotacoes);
                    GerarArquivo(moedas);
                    DateTime fimProcesso = DateTime.Now;
                    Console.WriteLine($"Fim do processamento: {fimProcesso.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"Tempo total do processamento: {fimProcesso.Subtract(inicioProcesso).TotalSeconds} segundos");
                    Console.WriteLine("---------------------------------------------------------------------------");
                }

            }

            Console.WriteLine("Novo ciclo de verificação iniciará em 2 minutos");
            System.Threading.Thread.Sleep(120000);
            await GetItem();

        }

        static List<DadosMoeda> SelecionarMoedasComCodigoCotacao(Moeda moeda)
        {
            List<DadosMoeda> lista = new List<DadosMoeda>();

            using (var streamReader = new StreamReader("DadosMoeda.csv"))
            {
                //pular cabeçalho
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {

                    var linha = streamReader.ReadLine();
                    var valores = linha.Split(';');

                    if (!(moeda.moeda.ToUpper() == valores[0].ToUpper())) continue;

                    DateTime dataInicio = Convert.ToDateTime(moeda.data_inicio);
                    DateTime dataFim = Convert.ToDateTime(moeda.data_fim);
                    DateTime dataDaMoeda = Convert.ToDateTime(valores[1]);

                    if (dataDaMoeda >= dataInicio && dataFim >= dataDaMoeda)
                    {
                        lista.Add(new DadosMoeda
                        {
                            IdMoeda = valores[0],
                            DataReferencia = dataDaMoeda,
                            CodigoCotacao = DePara.selecionarCodigoCotacao(valores[0]).CodigoCotacao
                        });
                    }

                }
            }

            return lista;
        }
        
        static List<DadosCotacao> ListarCotacoes()
        {
            List<DadosCotacao> lista = new List<DadosCotacao>();

            using (var streamReader = new StreamReader("DadosCotacao.csv"))
            {
                //pular cabeçalho
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {

                    var linha = streamReader.ReadLine();
                    var valores = linha.Split(';');

                    lista.Add(new DadosCotacao
                    {
                        CodCotacao = Int32.Parse(valores[1]),
                        VlrCotacao = Convert.ToDecimal(valores[0]),
                        DataReferencia = Convert.ToDateTime(valores[2])
                    });
                }

            }

            return lista;
        }
        
        static void ValorizarMoedas(List<DadosMoeda> moedas, List<DadosCotacao> cotacoes)
        {
            foreach(DadosMoeda moeda in moedas)
            {
                moeda.VlrCotacao = cotacoes.Where(c => c.DataReferencia == moeda.DataReferencia)
                                    .Select(c => c.VlrCotacao).FirstOrDefault();
            }
        }

        static void GerarArquivo(List<DadosMoeda> moedas)
        {
            StringBuilder buffer = new StringBuilder("ID_MOEDA;DATA_REF;VL_COTACAO\n");
            foreach (DadosMoeda moeda in moedas)
            {
                buffer.Append($"{moeda.IdMoeda};{moeda.DataReferencia.ToString("dd/MM/yyyy")};{moeda.VlrCotacao}\n");
            }
            
            string nomeDoArquivo = $"Resultado_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.csv";
            using (StreamWriter stream = new StreamWriter(nomeDoArquivo))
            {
                stream.Write(Convert.ToString(buffer));
                stream.Close();
            }            

        }

    }


}

