import React, { useState } from "react";

function renderPostTable() {
  return (
    <div className="table-responsive mt-5">
      <table className="table table-bordered table-dark">
        <thead>
          <tr>
            <th scope="col">PostId (PK)</th>
            <th scope="col">Title</th>
            <th scope="col">Content</th>
            <th scope="col">CRUD Operations</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">1</th>
            <td>Post 1 Title</td>
            <td>Post 1 Content</td>
            <td>
              <button className="btn btn-secondary btn-lg mx-4 my-3">Update</button>
              <button className="btn btn-danger btn-lg">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

export default function App() {
   const [post,setPost] = useState([]);

   function getPosts() {
      const url = 'https://localhost:7012/get-all-posts';

      fetch(url,{
         method:'GET'
      })
      .then(respone=> respone.json())
      .then(postsFromServer=>{
         console.log(postsFromServer);
         setPost(postsFromServer);
      })
      .catch(error=>{
         console.log(error);
         alert(error)
      });
   }
  return (
    <div className="container">
      <div className="row ">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>Content Post App</h1>
          </div>
          <div className="mt-5">
            <button onClick={getPosts} className="btn btn-dark btn-lg w-100">Get posts from Server</button>
            <button onClick={()=>{}} className="btn btn-secondary btn-lg w-100 mt-4">Create new Post</button>
          </div>
          {renderPostTable()}
        </div>
      </div>
    </div>
  );
}
