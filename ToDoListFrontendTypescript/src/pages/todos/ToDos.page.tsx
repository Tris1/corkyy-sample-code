import axios from "axios";
import { IToDo } from "../../types/global.types";
import "./todos.scss";
import { useState, useEffect } from "react";
import { baseUrl } from "../../constants/url.constant";
import { Button } from "@mui/material";
import { Edit, Delete } from "@mui/icons-material";
import moment from "moment";
import { useNavigate, useLocation } from "react-router-dom";
import Swal from "sweetalert2";

const ToDos: React.FC = () => {
  const [todos, setTodos] = useState<IToDo[]>([]);
  const location = useLocation();
  const redirect = useNavigate();

  const fetchToDosList = async () => {
    try {
      const response = await axios.get<IToDo[]>(baseUrl);
      setTodos(response.data);
      if (location?.state) {
        Swal.fire({
          icon: "success",
          title: location.state?.message,
        });

        redirect(location.pathname, { replace: true });
      }
    } catch (error) {
      alert("An Error Has Occured");
    }
  };

  useEffect(() => {
    fetchToDosList();
  }, []);

  const redirectToEditPage = (id: string) => {
    redirect(`/todos/edit/${id}`);
  };
  const redirectToDeletePage = (id: string) => {
    redirect(`/todos/delete/${id}`);
  };

  return (
    <div className="todos">
      <h1>ToDos</h1>
      {todos.length === 0 ? (
        <h1>No ToDos</h1>
      ) : (
        <div className="table-wrapper">
          <table>
            <thead>
              <tr>
                <th>ToDo</th>
                <th>Created</th>
                <th>Last Updated</th>
                <th>Operations</th>
              </tr>
            </thead>
            <tbody>
              {todos.map((todoItem) => (
                <tr key={todoItem.id}>
                  <td>{todoItem.todoText}</td>
                  <td>{moment(todoItem.created).fromNow()}</td>
                  <td>{moment(todoItem.updated).fromNow()}</td>
                  <td>
                    <Button
                      variant="outlined"
                      color="warning"
                      sx={{ mx: 3 }}
                      onClick={() => redirectToEditPage(todoItem.id)}
                    >
                      <Edit />
                    </Button>
                    <Button
                      variant="outlined"
                      color="error"
                      onClick={() => redirectToDeletePage(todoItem.id)}
                    >
                      <Delete />
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default ToDos;
