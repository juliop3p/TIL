import nodemailer from 'nodemailer';
import { IMailProvider, IMessage } from "../IMailProvider";
import Mail from 'nodemailer/lib/mailer';

export class MailtrapMailProvider implements IMailProvider {
  private transporter: Mail;
  
  constructor() {
    this.transporter = nodemailer.createTransport({
      host: 'smtp.mailtrap.io',
      port: 2525,
      auth: {
        user: 'b3e40b5c8e6c16',
        pass: 'a06abd92c83a04'
      }
    })
  }

  async sendMail(message: IMessage): Promise<void> {
    await this.transporter.sendMail({
      to: {
        name: message.to.name,
        address: message.to.email
      },
      from: {
        name: message.from.name,
        address: message.from.email
      },
      subject: message.subject,
      html: message.body,
    })
  }
}