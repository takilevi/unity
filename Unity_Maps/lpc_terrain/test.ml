(*
  Copyright 2013 by Mark Weyer
  Licensed under the OINM license version 0
*)

let pattern n ne e se s sw w nw =
  match w,e,n,s with
  | false,true,false,true -> 0,2
  | false,true,true,false -> 0,4
  | true,false,false,true -> 2,2
  | true,false,true,false -> 2,4
  | false,true,true,true -> (match ne,se with
    | false,true -> 3,1
    | true,false -> 3,2
    | true,true -> 0,3)
  | true,false,true,true -> (match nw,sw with
    | false,true -> 3,3
    | true,false -> 3,0
    | true,true -> 2,3)
  | true,true,false,true -> (match sw,se with
    | false,true -> 4,4
    | true,false -> 3,5
    | true,true -> 1,2)
  | true,true,true,false -> (match nw,ne with
    | false,true -> 4,5
    | true,false -> 3,4
    | true,true -> 1,4)
  | true,true,true,true -> (match nw,ne,sw,se with
    | false,true,true,false -> 4,1
    | true,false,false,true -> 4,2
    | false,true,true,true -> 2,1
    | true,false,true,true -> 1,1
    | true,true,false,true -> 2,0
    | true,true,true,false -> 1,0
    | true,true,true,true -> 1,3)

;;

Sdl.init [`VIDEO;`TIMER];
Sdlevent.disable_events Sdlevent.all_events_mask;
Sdlevent.enable_events Sdlevent.keydown_mask;
let screen = Sdlvideo.set_video_mode ~w:800 ~h:800 ~bpp:32 []  in

Random.self_init ();

let sheet = Sdlloader.load_image Sys.argv.(1)  in

let quit = ref false  in
while not !quit do
  Sdlvideo.fill_rect screen (Sdlvideo.map_RGB screen (0,0,0));

  let present = Array.make_matrix 27 27 false  in
  for i = 0 to 25 do
    for j = 0 to 25 do
      let p = float_of_int (i+j) /. 100.0  in
      if p>=Random.float 1.0
      then for i'=i to i+1 do for j'=j to j+1 do
          present.(i').(j') <- true
        done done
    done
  done;

  for i=1 to 25 do
    for j=1 to 25 do
      if present.(i).(j)
      then
        let x,y = pattern
	  present.(i).(j-1) present.(i+1).(j-1)
	  present.(i+1).(j) present.(i+1).(j+1)
	  present.(i).(j+1) present.(i-1).(j+1)
	  present.(i-1).(j) present.(i-1).(j-1)  in
        Sdlvideo.blit_surface
          ~src:sheet ~src_rect:(Sdlvideo.rect (x*32) (y*32) 32 32)
          ~dst:screen ~dst_rect:(Sdlvideo.rect ((i-1)*32) ((j-1)*32) 32 32) ()
    done
  done;

  Sdlvideo.update_rect screen;
  match Sdlevent.wait_event () with
  | Sdlevent.KEYDOWN ke -> quit := ke.Sdlevent.keysym = Sdlkey.KEY_ESCAPE
  | _ -> ();
done;

Sdl.quit ();

