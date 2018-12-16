using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSaver.Utilities.Tests
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public async Task EnviarEmail_ValidEmail_SendEmail()
        {
            var emailEntity = new Email();
            
            emailEntity.EnviarEmail("Assunto", "Conteudo", "phtrind@hotmail.com", false);
        }

        [TestMethod]
        public async Task EnviarEmail_HtmlEncoded_SendEmail()
        {
            var emailEntity = new Email();
            
            emailEntity.EnviarEmail("Correção cadastro de anúncio", @"<!DOCTYPE html> <!-- saved from url=(0014)about:internet --> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <title>cadastro.png</title> <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /> <style type='text/css'>td img {display: block;}</style> <!--Fireworks CS6 Dreamweaver CS6 target. Created Mon Dec 10 23:42:14 GMT-0200 2018-->

<link href='https://fonts.googleapis.com/css?family=Work+Sans' rel='stylesheet'>

<style> body { font-family: 'Work Sans', sans-serif; color: #500B89; } </style> </head> <body style='text-align: center'> <table style='display: inline-table;' bgcolor='#c6acce' border='0' cellpadding='0' cellspacing='0' width='600'> <!-- fwtable fwsrc='cadastro.fw.png' fwpage='Página 1' fwbase='cadastro.png' fwstyle='Dreamweaver' fwdocid = '1615885160' fwnested='0' --> <tr> <td><img src='spacer.gif' width='600' height='1' alt='' /></td> <td><img src='spacer.gif' width='1' height='1' alt='' /></td> </tr>

 <tr> <td><a href='http://www.petsaver.com.br' target='_blank'><img name='cadastro_r1_c1' src='http://i65.tinypic.com/2a9y3v6.jpg' width='600' height='191' id='cadastro_r1_c1' alt='' /></a></td> <td><img src='spacer.gif' width='1' height='191' alt='' /></td> </tr> <tr> <td style='text-align: left; padding: 20px; font-size: 18px'> <p>Olá Saver, tudo bem?</p> <p>Verificamos que pode ter ocorrido um erro ao tentar cadastrar o seu anúncio.</p> <p>O problema foi solucionado e por isso pedimos que tente realizar o cadastro novamente.</p> <p>O seu feedback é essencial para juntos salvarmos a vida de milhões de pets.</p> <p>#SouPetSaver</p> </td> <td><img src='spacer.gif' width='1' height='200' alt='' /></td> </tr> <tr> <td><a href='https://www.instagram.com/soupetsaver/' target='_blank'><img name='cadastro_r3_c1' src='http://i68.tinypic.com/8zekw0.png' width='600' height='196' id='cadastro_r3_c1' alt='' /></a></td> <td><img src='spacer.gif' width='1' height='196' alt='' /></td> </tr> </table> </body> </html> ", "lorrayne.20@hotmail.com", true);
        }
    }
}
