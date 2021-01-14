using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZoomClient.ConsoleApp.Meetings
{
    public class CriarMeeting: ItemMenuBase
    {
        public CriarMeeting(IItemMenu menuPai)
            :base(menuPai, "Criar Meeting")
        {

        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine();
            do
            {
                Console.WriteLine("Digite o Topico:");
                string topico = Console.ReadLine();
                string anfitriao = SelecionarAnfitriao();

                if (!MensagemConfirmacao("Confirma a Inclusão? (S/N)", "SsSimsim"))
                {
                    LimparTela();
                    Cabecalho();
                    continue;
                }
                Meeting meeting = Program.ZoomClient.Meetings.CreateMeeting(anfitriao, Criar(topico));
                Console.WriteLine("Meeting Criado");
                Console.WriteLine($"{meeting.Id}, {meeting.Topic} - {meeting.JoinUrl}");

                do
                {
                    Console.WriteLine("Digite o email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Digite um Primeiro Nome:");
                    string primeiroNome = Console.ReadLine();
                    Console.WriteLine("Digite um Sobrenome:");
                    string sobreNome = Console.ReadLine();
                    Program.ZoomClient.Meetings.CreateMeetingRegistrant(meeting.Id, new CreateMeetingRegistrant
                    {
                        Email = email,
                        FirstName = primeiroNome,
                        LastName = sobreNome
                    });

                }
                while (MensagemConfirmacao("Adicionar outro Participante? (S/N)", "SsSimsim"));

            }
            while (MensagemConfirmacao("Adicionar outro Meeting? (S/N)", "SsSimsim"));
            PressioneQualquerTecla();
        }

        private Dictionary<int, User> ListarUsuarios()
        {
            Dictionary<int, User> anfitrioes = new Dictionary<int, User>();
            var allUsers = Program.ZoomClient.Users.GetUsers(UserStatuses.Active);

            int index = 0;
            foreach (var user in allUsers.Users)
            {
                index++;
                anfitrioes.Add(index, user);
                Console.WriteLine($"{index:00}- {user.FirstName} {user.LastName}, email: {user.Email}");
            }

            return anfitrioes;
        }

        private string SelecionarAnfitriao()
        {
            
            Dictionary<int, User> users = ListarUsuarios();
            bool semSelecao = true;
            int opcao = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Selecione um Anfitrião.");
                opcao = int.Parse(Console.ReadLine());

                semSelecao = !users.ContainsKey(opcao);
            }
            while (semSelecao);

            return users[opcao].Email;
        }


        private Meeting Criar(string topico, string password = null)
        {
            return new Meeting
            {
                Duration = 60,
                Password = password,
                Settings = new MeetingSettings
                {
                    EnableHostVideo = true,
                    EnableParticipantVideo = false,
                    EnableJoinBeforeHost = false,
                    ApprovalType = MeetingApprovalTypes.Manual,
                    AutoRecording = MeetingAutoRecordingOptions.None,
                    EnableEnforceLogin = true
                },
                StartTime = DateTimeOffset.Now.AddMinutes(2),
                Topic = topico,
                Type = MeetingTypes.Scheduled,
            };


        }
    }
}
