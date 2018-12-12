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
            
            emailEntity.EnviarEmail("Olá Saver!", @"<!DOCTYPE html>
<!-- saved from url=(0014)about:internet -->
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
<title>anuncio com interesse concretizado.png</title>
<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
<style type='text/css'>td img {display: block;}</style>
<!--Fireworks CS6 Dreamweaver CS6 target.  Created Mon Dec 10 23:33:46 GMT-0200 2018-->
</head>
<body>
<table style='display: inline-table;' bgcolor='#c6acce' border='0' cellpadding='0' cellspacing='0' width='600'>
<!-- fwtable fwsrc='anuncio com interesse concretizado.fw.png' fwpage='Página 1' fwbase='anuncio com interesse concretizado.png' fwstyle='Dreamweaver' fwdocid = '1615885160' fwnested='0' -->
  <tr>
   <td><img src='spacer.gif' width='600' height='1' alt='' /></td>
   <td><img src='spacer.gif' width='1' height='1' alt='' /></td>
  </tr>

  <tr>
   <td><img name='anunciocominteresseconcretizado_r1_c1' src='http://i65.tinypic.com/2a9y3v6.png' width='600' height='191' id='anunciocominteresseconcretizado_r1_c1' alt='' /></td>
   <td><img src='spacer.gif' width='1' height='191' alt='' /></td>
  </tr>
  <tr>
   <td><img name='anunciocominteresseconcretizado_r2_c1' src='http://i67.tinypic.com/2zyfkgo.png' width='600' height='728' id='anunciocominteresseconcretizado_r2_c1' alt='' /></td>
   <td><img src='spacer.gif' width='1' height='728' alt='' /></td>
  </tr>
  <tr>
   <td><a href='http://petsaver.com.br/' target='_blank'><img name='anunciocominteresseconcretizado_r3_c1' src='http://i63.tinypic.com/2v1lpuh.png' width='600' height='193' id='anunciocominteresseconcretizado_r3_c1' alt='' /></a></td>
   <td><img src='spacer.gif' width='1' height='193' alt='' /></td>
  </tr>
</table>
</body>
</html>", "phtrind@hotmail.com", true);
        }
    }
}
