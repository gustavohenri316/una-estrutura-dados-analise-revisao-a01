using System;

class Atividade01
{
  static void Main(string[] args)
    {
        string nome;
        int idade;
        bool cartaoVacinacao;
        bool teveSintomas;
        bool teveContatoComInfectados;
        bool retornouDeViagem;

        Console.WriteLine("Informe o seu nome:");
        nome = Console.ReadLine();

        Console.WriteLine("Informe a sua idade:");
        idade = int.Parse(Console.ReadLine());

        cartaoVacinacao = Perguntar("Seu cartão de vacina está em dia? (SIM/NAO)");
        teveSintomas = Perguntar("Teve algum dos sintomas recentemente? (SIM/NAO)");
        teveContatoComInfectados = Perguntar("Teve contato com pessoas com sintomas gripais nos últimos dias? (SIM/NAO)");
        retornouDeViagem = Perguntar("Está retornando de viagem realizada no exterior? (SIM/NAO)");

        double porcentagemRisco = CalcularPorcentagemRisco(cartaoVacinacao, teveSintomas, teveContatoComInfectados, retornouDeViagem);

        Console.WriteLine("\nRelatório de Triagem:");
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Idade: {idade}");
        Console.WriteLine($"Cartão de Vacinação em Dia: {(cartaoVacinacao ? "SIM" : "NAO")}");
        Console.WriteLine($"Teve Sintomas Recentes: {(teveSintomas ? "SIM" : "NAO")}");
        Console.WriteLine($"Teve Contato com Pessoas Infectadas: {(teveContatoComInfectados ? "SIM" : "NAO")}");
        Console.WriteLine($"Retornou de Viagem: {(retornouDeViagem ? "SIM" : "NAO")}");
        Console.WriteLine($"Porcentagem de Risco: {porcentagemRisco}%");

        string orientacao = ObterOrientacao(porcentagemRisco, retornouDeViagem);
        Console.WriteLine(orientacao);

        Console.ReadKey();
    }

    static bool Perguntar(string pergunta)
    {
        int tentativas = 0;
        while (tentativas < 3)
        {
            Console.WriteLine(pergunta);
            string resposta = Console.ReadLine().Trim().ToUpper();
            if (resposta == "SIM")
                return true;
            else if (resposta == "NAO")
                return false;

            tentativas++;
        }

        Console.WriteLine("Não foi possível realizar o diagnóstico.");
        Console.WriteLine("Gentileza procurar ajuda médica caso apareça algum sintoma.");
        Environment.Exit(0);
        return false;
    }

    static double CalcularPorcentagemRisco(bool cartaoVacinacao, bool teveSintomas, bool teveContatoComInfectados, bool retornouDeViagem)
    {
        double porcentagem = 0;

        if (!cartaoVacinacao)
            porcentagem += 10;

        if (teveSintomas)
            porcentagem += 30;

        if (teveContatoComInfectados)
            porcentagem += 30;

        if (retornouDeViagem)
            porcentagem += 30;

        return porcentagem;
    }

    static string ObterOrientacao(double porcentagemRisco, bool retornouDeViagem)
    {
        if (retornouDeViagem)
        {
            return "Você ficará sob observação por 05 dias.";
        }
        else if (porcentagemRisco <= 30)
        {
            return "Paciente sob observação. Caso apareça algum sintoma, gentileza buscar assistência médica.";
        }
        else if (porcentagemRisco <= 60)
        {
            return "Paciente com risco de estar infectado. Gentileza aguardar em lockdown por 02 dias para ser acompanhado.";
        }
        else if (porcentagemRisco <= 89)
        {
            return "Paciente com alto risco de estar infectado. Gentileza aguardar em lockdown por 05 dias para ser acompanhado.";
        }
        else
        {
            return "Paciente crítico! Gentileza aguardar em lockdown por 10 dias para ser acompanhado.";
        }
    }
}
