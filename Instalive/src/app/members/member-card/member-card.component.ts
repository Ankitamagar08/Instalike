import { Component, Input, OnInit } from '@angular/core';
import { Toast, ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
 @Input() member: Member;
  constructor(private memberService: MembersService, private tostr:ToastrService) { }

  ngOnInit(): void {
  }

   addLike(member: Member){
     this.memberService.addLike(member.username).subscribe(()=>{
       this.tostr.success('You have liked ' + member.knownAs);
     })
   }
}
