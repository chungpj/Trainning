const posts = [ 
	{id: 1, name: 'First post'},
	{id: 2, name: 'Second post'}
];
getPosts = () => {
	setTimeout(() => {
		let output = '';
		posts.forEach((post, index) => {
			output += `<li>${post.name}</li>`
		});
		document.getElementById("demo").innerHTML = output;
	}, 2000);
}
createPost = (post) => {
	return new Promise((resolve, reject) => {
		setTimeout(() => {
			posts.push(post);
			
			//change err value 
			const err = false;
			if(!err){
				resolve();
			}else {
				reject('Error: createPost failed!');
			}
		}, 2000);
	});
}

fetchUsers = async () => {
	const res = await fetch('https://jsonplaceholder.typicode.com/users');
	const data = await res.json();
	
	console.log(data);
}

Init = async () => {
	document.getElementById("title").innerHTML = 'Demo Async/Await';
	
	//await createPost({id: 3, name: 'Third post'});
	
	fetchUsers();
}

Init();