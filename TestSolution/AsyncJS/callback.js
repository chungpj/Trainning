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

createPost = (post, callback) => {
	setTimeout(() => {
		posts.push(post);
		callback();
	}, 1000);
}

Init = () => {
	document.getElementById("title").innerHTML = 'Demo Callback';
	
	createPost({id: 3, name: 'Third post'}, getPosts);
}

Init();