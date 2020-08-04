import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/_services/evento.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/_models/Evento';

@Component({
  selector: 'app-evento-edit',
  templateUrl: './eventoEdit.component.html',
  styleUrls: ['./eventoEdit.component.css']
})
export class EventoEditComponent implements OnInit {

  titulo = 'Editar Evento';
  //evento = {};
  evento: Evento = new Evento()
  imagemURL = 'assets/img/upload.png';
  registerForm: FormGroup;
  file: File;
  fileNameToUpdate: string;

  dataAtual = '';
  constructor(
    private eventoService: EventoService
  , private modalService: BsModalService
  , private fb: FormBuilder
  , private localeservice: BsLocaleService
  , private toastr: ToastrService
  )
  {
    this.localeservice.use('pt-br');
  }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      imagemURL: [''],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      lotes: this.fb.group({
        nome: ['', Validators.required],
        quantidade: ['', Validators.required],
        preco: ['', Validators.required],
        dataInicio: [''],
        dataFim: ['']      
      }),
      redesSociais: this.fb.group({
        nome: ['', Validators.required],
        url: ['', Validators.required]
      })
    });
  }

  onFileChange(evento: any, file: FileList) {
    const reader = new FileReader();

    reader.onload = (event: any) => this.imagemURL = event.target.result;

    this.file = evento.target.files;
    reader.readAsDataURL(file[0]);
  }

}
